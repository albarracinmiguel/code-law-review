---
name: doctrine
description: Extract domain invariants (deletion, tenancy, billing rules) from wiki pages and propose them as candidate rules for `codes/`. Use when asked to import or refresh domain rules from the wiki.
---

# /doctrine

Read domain documentation and propose **invariants**: statements that must always be true about the business, and that code can violate.

**You never write to `codes/`.** Output goes to `notes/gazette/candidates.md`.

## Inputs

- Real mode: the wiki pages listed in `docs/domain/README.md` (through the wiki's MCP connector or API).
- Demo mode: `docs/domain/*.md`.
- Current law: accepted ADRs (`constitution/`) and enacted rules (`codes/`).

## Steps

1. **Read** each page. Note its last-edited date.
2. **Extract invariants.** Only statements code can break. Good: "Deleted add-ons are never billed". Not an invariant: "Billing is owned by the Billing team".
3. **Check freshness and conflicts.** For each invariant:
   - Contradicts an accepted ADR → `CONFLICT`. The ADR wins. Propose a wiki fix instead of a rule.
   - Contradicts an enacted rule in `codes/` → `CONFLICT`. Recent case law wins. Report it.
   - Already covered by a rule in `codes/` → skip, or suggest adding the page to its `cites`.
   - Page older than the ADRs it touches → flag `STALE PAGE`.
4. **Write** candidates to the Gazette with `source: doctrine`, the page path and the exact sentence it came from.

## Output to the user
Number of pages read, invariants proposed, conflicts and stale pages, and the Gazette path.
