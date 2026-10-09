# Guidelines (the Codes)

The rules in force for this repo. Every entry here was **enacted by a human** from the Gazette (`notes/gazette/candidates.md`).

Agents read these files. Agents never write them.

## Files

| File | Prefix | Prosecutor that enforces it |
|---|---|---|
| [data.md](data.md) | `DATA-` | `prosecutor-data` |
| [money.md](money.md) | `MONEY-` | `prosecutor-money` |
| [api.md](api.md) | `API-` | `prosecutor-architecture` |
| [tests.md](tests.md) | `TEST-` | `prosecutor-tests` |

## Entry format

```markdown
## DATA-007 · Short imperative title
status: enacted | repealed
default severity: critical | major | optional | nit
source: case law | doctrine | ADR-XXXX
rule: One sentence. What must be true.
why: Why this repo does it this way (often an ADR).
cites: MR numbers and number of distinct reviewers.
bad: smallest example that breaks it
good: smallest example that follows it
```

Rules:

- An ID is never reused. A repealed rule keeps its ID with `status: repealed`.
- `cites` must point to real threads or an ADR. A rule with no source is not enacted.
- A rule can't contradict an accepted ADR. If it does, it goes back to the Gazette as a conflict.
