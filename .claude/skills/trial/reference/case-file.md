# The case file

Built once per MR by the `clerk` agent. Every other agent reads it instead of fetching things itself.

## What it contains

```markdown
# Case file · <TICKET-ID> · MR !<number>
asked:     one sentence: what the ticket asks for
ac:        acceptance criteria, numbered AC-1, AC-2…
diff:      files changed, grouped by folder, +/− lines
touches:   money | data | tenancy | security | api | tests   (tags for routing)
adrs:      accepted ADRs relevant to the touched areas
rules:     guideline files relevant to the touched areas
humans:    existing human review comments on the MR (protected)
```

## Tracker-agnostic

The case file only needs a **title**, **acceptance criteria** and **links**. Each tracker gets a small adapter that fills those three fields:

| Tracker | How the clerk gets the ticket |
|---|---|
| Jira | Atlassian MCP connector or REST `GET /issue/{key}` |
| Linear | Linear MCP connector or GraphQL `issue(id)` |
| Azure Boards | `az boards work-item show --id` |
| GitHub/GitLab issues | `gh issue view` / `glab issue view` |
| **Demo** | `sample/tickets/<TICKET-ID>.md` |

Where the ticket ID comes from: the branch name (`feature/PROJ-1234-…`), else the MR title, else ask.

## Demo mode

- Diff: `sample/diff/<TICKET-ID>.diff`
- Ticket: `sample/tickets/<TICKET-ID>.md`
- Human comments: none (the MR is new)
