#!/usr/bin/env python3
"""Validate basic Markdown hygiene and relative links without external dependencies."""

from __future__ import annotations

import re
import sys
from pathlib import Path
from urllib.parse import unquote

ROOT = Path(__file__).resolve().parents[1]
MARKDOWN_LINK = re.compile(r"!?\[[^\]]*\]\(([^)]+)\)")


def markdown_files() -> list[Path]:
    return sorted(path for path in ROOT.rglob("*.md") if ".git" not in path.parts)


def validate_file(path: Path) -> list[str]:
    errors: list[str] = []
    text = path.read_text(encoding="utf-8")

    if not text.endswith("\n"):
        errors.append(f"{path.relative_to(ROOT)}: arquivo deve terminar com nova linha")

    for number, line in enumerate(text.splitlines(), start=1):
        if line.rstrip() != line:
            errors.append(f"{path.relative_to(ROOT)}:{number}: espacos no fim da linha")

        for target in MARKDOWN_LINK.findall(line):
            target = target.strip().split("#", 1)[0]
            if not target or target.startswith(("http://", "https://", "mailto:")):
                continue
            candidate = (path.parent / unquote(target)).resolve()
            if ROOT not in candidate.parents and candidate != ROOT:
                errors.append(f"{path.relative_to(ROOT)}:{number}: link sai da raiz: {target}")
            elif not candidate.exists():
                errors.append(f"{path.relative_to(ROOT)}:{number}: link relativo inexistente: {target}")

    return errors


def main() -> int:
    files = markdown_files()
    if not files:
        print("Nenhum arquivo Markdown encontrado.", file=sys.stderr)
        return 1

    errors = [error for path in files for error in validate_file(path)]
    if errors:
        print("\n".join(errors), file=sys.stderr)
        return 1

    print(f"Documentacao validada: {len(files)} arquivos Markdown.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
