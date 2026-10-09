# Severity and the merge gate

| Level | Meaning | Merge gate | Evidence needed |
|---|---|---|---|
| `critical` | Breaks data, money, security or an acceptance criterion | **Blocks the merge** | `REPRODUCED` by the expert witness |
| `major` | Breaks an enacted guideline or an accepted ADR | Reply required (fix or explain) | Rule ID + `file:line` |
| `optional` | A better way, a judgment call | Non-blocking | Jury majority (full trial) |
| `nit` | Naming, style, formatting | Non-blocking, batched in one thread | Jury majority (full trial) |

## Special states

| State | Meaning | Who decides |
|---|---|---|
| `DISPUTED` | Contested by the defense, or claimed critical but not reproduced | The judge. Posted first. |
| `SETTLED` | Suggests something an accepted ADR rejected | Closed, ADR cited |
| `CONFLICT` | A rule contradicts a higher one | Reported, never enforced |

## Aggravated matters

Findings about money, data integrity or security (tenancy included) can't be downgraded by any agent. If the evidence isn't enough for `critical`, they become `DISPUTED` with "claimed: critical", never `major`.

## The gate

```
gate = FAIL  if any finding has severity=critical and state=open
gate = PASS  otherwise
```

The judge closes a critical thread by replying:
- `confirm` → the author must fix; the thread stays open until a new commit resolves it and the gate re-runs;
- `overrule: <reason>` → closed. The reason is mandatory and is harvested by `/case-law` later.
