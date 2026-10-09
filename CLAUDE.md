# CLAUDE.md

This repo is a demo of the **Case Law Review** process. Read `README.md` first.

## Ground rules for any session in this repo

- The law lives in three places, in this order of precedence:
  1. `docs/adr/` with `Status: Accepted` (the Constitution). `Superseded` ADRs are repealed: never cite them.
  2. `.claude/guidelines/` (the Codes). Only rules with `status: enacted` apply.
  3. Case law and doctrine only interpret the above.
- Never write to `.claude/guidelines/` directly. New rules go to `notes/gazette/candidates.md` and a human enacts them.
- Every finding cites a rule ID and a `file:line`. No evidence, no finding.
- Never resolve or dismiss a human review comment.
- Severities: `critical`, `major`, `optional`, `nit`. See `.claude/skills/trial/reference/severity.md`.

## Demo mode

There is no GitLab, tracker or wiki connected. Skills read local stand-ins:

| Real source | Local stand-in |
|---|---|
| MR diff | `sample/diff/<TICKET>.diff` |
| Ticket | `sample/tickets/<TICKET>.md` |
| MR review threads | `notes/case-law/raw/*.md` |
| Wiki | `docs/domain/*.md` |
