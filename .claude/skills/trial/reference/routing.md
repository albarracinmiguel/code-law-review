# Routing: which trial, which prosecutors

## Summary trial vs full trial

| | Summary trial | Full trial |
|---|---|---|
| Prosecution | `prosecutor-generalist` (fixed lenses) | Specialists, routed by path |
| Defense | none | `defense` |
| Expert witness | verifies every critical/major | verifies every critical/major |
| Jury | none: taste stays a nit | 3 × `jury` |
| Runs when | default | any trigger below |

### Full trial triggers
- `touches` includes `money`, `data`, `tenancy` or `security`
- more than 400 changed lines or more than 15 files
- a human reviewer asks for it (`/trial <id> --full`)

## Prosecutor routing (full trial)

| Prosecutor | Runs when the diff touches | Always? |
|---|---|---|
| `prosecutor-money` | `**/Billing/**`, `decimal`, `Math.Round`, `Money.` | **yes** (aggravated) |
| `prosecutor-security` | auth, tenancy, controllers, `ITenantContext` | **yes** (aggravated) |
| `prosecutor-data` | `DbContext`, `*.Data/**`, LINQ queries, migrations | when matched |
| `prosecutor-architecture` | new projects, controllers, events, references between layers | when matched |
| `prosecutor-tests` | `*.Tests/**`, or a `fix:` MR without test changes | when matched |

Money and security prosecutors run in every full trial, even if no path matches: a missed match there is the costliest mistake.

## Model and effort per role (dials to tune)

| Role | Model | Why |
|---|---|---|
| clerk | haiku | mechanical: fetch and format |
| prosecutors, defense | opus | judgment |
| expert-witness | sonnet | writes and runs repros |
| jury | sonnet | short votes on taste |
