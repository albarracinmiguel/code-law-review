# Templates

One template per artifact in the process. Agents and skills fill these; humans use them when writing by hand.

Copy the file, replace every `<placeholder>`, delete the comments (`<!-- … -->`).

| Template | Produces | Who fills it | Where it goes |
|---|---|---|---|
| [adr.md](adr.md) | An ADR (Constitution) | Human | `constitution/ADR-NNNN-<slug>.md` |
| [domain-page.md](domain-page.md) | A wiki page with invariants (Doctrine source) | Human | Wiki (`docs/domain/` in demo) |
| [ticket.md](ticket.md) | A ticket with acceptance criteria | Human | Any tracker (`sample/tickets/` in demo) |
| [case-law-run.md](case-law-run.md) | The record of one `/case-law` or `/doctrine` run | `/case-law`, `/doctrine` | `notes/case-law/runs/`, `notes/doctrine/runs/` |
| [gazette-candidate.md](gazette-candidate.md) | A candidate rule | `/case-law`, `/doctrine` | `notes/gazette/candidates.md` |
| [guideline-entry.md](guideline-entry.md) | An enacted rule (Codes) | Human, from an approved candidate | `codes/<area>.md` |
| [case-file.md](case-file.md) | The case file for one MR | `clerk` | `notes/cases/<ID>/case-file.md` |
| [trial-record.md](trial-record.md) | Everything that happened in a trial | `/trial` | `notes/cases/<ID>/trial-record.md` |
| [verdict.json](verdict.json) | Machine-readable result for CI | `/trial` | `notes/cases/<ID>/verdict.json` |
| [mr-comment.md](mr-comment.md) | MR threads, one per finding, plus judge replies | `/trial`, judge | The MR |
| [agent-prosecutor.md](agent-prosecutor.md) | A new specialist prosecutor | Human | `.claude/agents/prosecutor-<area>.md` |
| [skill.md](skill.md) | A new skill in this process | Human | `.claude/skills/<name>/SKILL.md` |

## How they connect

```
ticket.md ──┐
diff ───────┼─► case-file.md ─► trial-record.md ─► verdict.json ─► mr-comment.md
adr.md ─────┘                                                          │
                                                                        ▼ judge replies
domain-page.md ─► gazette-candidate.md ◄──────────────── /case-law harvests threads
                          │ human enacts
                          ▼
                  guideline-entry.md ─► read by every prosecutor
```
