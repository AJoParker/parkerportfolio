#!/usr/bin/env bash
#
# Regenerates docs/ — the static bundle GitHub Pages serves.
#
# Pages is configured as: Deploy from a branch -> main -> /docs
# Live at https://ajoparker.github.io/parkerportfolio/
#
# docs/ is fully owned by this script. Do not hand-edit anything inside it;
# every run wipes and rebuilds it. Commit the result.

set -euo pipefail

BASE_PATH="/parkerportfolio/"
ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
STAGE="$ROOT/bin/pages-publish"
OUT="$ROOT/docs"

dotnet publish "$ROOT/ParkerPortfolio.csproj" -c Release -o "$STAGE"

rm -rf "$OUT"
mkdir -p "$OUT"
cp -R "$STAGE/wwwroot/." "$OUT/"

# GitHub Pages compresses on its own and never serves these precompressed copies
find "$OUT" \( -name '*.br' -o -name '*.gz' \) -delete

# Retarget the bundle at the project subpath. Source keeps <base href="/" /> so
# `dotnet run` still works at the root locally.
if [[ "$OSTYPE" == darwin* ]]; then
    sed -i '' "s|<base href=\"/\" />|<base href=\"$BASE_PATH\" />|" "$OUT/index.html"
else
    sed -i "s|<base href=\"/\" />|<base href=\"$BASE_PATH\" />|" "$OUT/index.html"
fi

grep -q "<base href=\"$BASE_PATH\" />" "$OUT/index.html" || {
    echo "error: base href rewrite failed — did wwwroot/index.html change?" >&2
    exit 1
}

# SPA fallback. Pages serves 404.html for any unmatched path; it boots the app
# and the Blazor router resolves the URL from window.location.
cp "$OUT/index.html" "$OUT/404.html"

# Without this, Jekyll strips every directory starting with _ — including the
# entire _framework/ runtime.
touch "$OUT/.nojekyll"

echo "docs/ regenerated for ${BASE_PATH} ($(du -sh "$OUT" | cut -f1))"
