# CLAUDE.md

This repo is a demo of the **Case Law Review** process. Read `README.md` first.

## Ground rules for any session in this repo

- The law lives in three places, in this order of precedence:
  1. `constitution/` with `Status: Accepted` (the Constitution). `Superseded` ADRs are repealed: never cite them.
  2. `codes/` (the Codes). Only rules with `status: enacted` apply.
  3. Case law and doctrine only interpret the above.
- Never write to `codes/` directly. New rules go to `notes/gazette/candidates.md` and a human enacts them.
- Every finding cites a rule ID and a `file:line`. No evidence, no finding.
- Never resolve or dismiss a human review comment.
- Severities: `critical`, `major`, `optional`, `nit`. See `.claude/skills/trial/reference/severity.md`.

## Templates

Every artifact of the process has a template in `templates/`. When a skill or agent writes one of these, it follows the template's structure exactly:

| Writing… | Use |
|---|---|
| `notes/cases/<ID>/case-file.md` | `templates/case-file.md` |
| `notes/cases/<ID>/trial-record.md` | `templates/trial-record.md` |
| `notes/cases/<ID>/verdict.json` | `templates/verdict.json` |
| MR threads or `mr-comments.md` | `templates/mr-comment.md` |
| A run record in `notes/case-law/runs/` or `notes/doctrine/runs/` | `templates/case-law-run.md` |
| A candidate in `notes/gazette/candidates.md` | `templates/gazette-candidate.md` |
| A rule in `codes/` (humans only) | `templates/guideline-entry.md` |
| An ADR | `templates/adr.md` |
| A new prosecutor or skill | `templates/agent-prosecutor.md`, `templates/skill.md` |

When `/case-law` harvests, it also keeps **human replies inside Smart Review threads** (judge rulings: `confirm`, `confirm. <reason>`, `overrule: <reason>`). Only the bot's own text is dropped.

## Demo mode

There is no GitLab, tracker or wiki connected. Skills read local stand-ins:

| Real source | Local stand-in |
|---|---|
| MR diff | `sample/diff/<TICKET>.diff` |
| Ticket | `sample/tickets/<TICKET>.md` |
| MR review threads | `notes/case-law/raw/*.md` |
| Wiki | `docs/domain/*.md` |
