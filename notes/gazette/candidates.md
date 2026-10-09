# Official Gazette · candidate rules

Rules proposed by `/case-law` and `/doctrine`. **Nothing here is law until a human sets `status: enacted`** and copies it to `codes/`.

Runs: [`/case-law` 2025-10-01](../case-law/runs/2025-10-01.md) (!412, !518, !603) · [`/doctrine` 2025-10-02](../doctrine/runs/2025-10-02.md) · [`/case-law` 2025-10-15](../case-law/runs/2025-10-15.md) (!701, the PROJ-1234 MR)

| ID | Proposed rule | Source | Signals | Status |
|---|---|---|---|---|
| C-01 | DATA-007 · Filter soft-deleted rows explicitly | case law | 3 MRs · 2 reviewers · changed after: 3/3 | ✅ enacted 2025-10-01 by Ana |
| C-02 | MONEY-003 · Round money away from zero, once per line | case law + ADR-0012 | 1 MR here (+2 older) · code changed: yes | ✅ enacted 2025-10-01 by Bruno |
| C-03 | DATA-011 · Children of a deleted parent count as deleted | doctrine | soft-delete.md | ✅ enacted 2025-10-02 by Ana |
| C-04 | TEST-006 · Fixtures must not agree with the code by construction | case law | 1 MR here (+1 older) · 2 reviewers | ✅ enacted 2025-10-02 by Carla |
| C-05 | "Store money as double, round on display" | doctrine | billing.md (Nov 2024) | ⚠️ **CONFLICT** with ADR-0012 |
| C-06 | "Use `HasQueryFilter` for soft delete" | case law | !412 thread 4 | ⚖️ **SETTLED** by ADR-0004 |
| C-07 | "Round the invoice total, not each line" | case law | !603 thread 4 · 1 reviewer · ended in disagreement | ⚖️ **SETTLED** by ADR-0012 |
| C-08 | NAME-001 · Query method names say what they return | case law | 2 MRs · 2 reviewers · changed after: 2/2 | ⏳ pending |
| C-09 | MONEY-005 · Compute tax per invoice line, then sum | case law | 2 MRs · 2 reviewers · from a judge's ruling on !701 | ⏳ pending |

---

## C-05 · CONFLICT

- **Proposed by:** `/doctrine`
- **From:** `docs/domain/billing.md` — "Amounts are stored as `double` and rounded to 2 decimals when displayed."
- **Conflicts with:** ADR-0012 (Accepted), which repealed ADR-0002 for exactly this reason.
- **Action:** not enacted. Suggested fix: update the wiki page. Owner: Billing team.

## C-06 · SETTLED

- **Proposed by:** `/case-law`
- **From:** !412 thread 4 (Bruno), withdrawn in the same thread.
- **Settled by:** ADR-0004, "Alternatives considered: EF Core global query filters. Rejected."
- **Action:** none. Kept here so nobody re-proposes it.

## C-07 · SETTLED

- **From:** !603 thread 4 (Carla). Only 1 reviewer, thread ended in disagreement.
- **Settled by:** ADR-0012, Decision point 3.

## C-08 · pending

```
## NAME-001 · Query method names say what they return
status: pending
default severity: nit
source: case law
rule: Methods that read data are named after what they return, not after the action (`ListActiveForCustomer`, not `GetData`).
why: Readers can tell what a query filters without opening it.
cites: !412 (Ana), !518 (Carla) · 2 distinct reviewers
bad:  GetData(customerId)
good: ListActiveForCustomer(customerId)
```

## C-09 · pending

- **Proposed by:** `/case-law` (run 2025-10-15)
- **From:** !701 thread 1, **Ana's ruling** on a DISPUTED finding · !603 thread 4 (Bruno)
- **Signals:** 2 MRs · 2 reviewers · code changed after: 1/2
- **Relation to the law:** compatible with ADR-0012 decision 3 (round once per line) and more specific: it says where the tax is computed, not only where it's rounded.

```
## MONEY-005 · Compute tax per invoice line, then sum
status: pending
default severity: critical
source: case law + ADR-0012
rule: Tax is computed and rounded on each invoice line with Money.Round, then summed. Never computed on the subtotal.
why: Rounding per line and rounding the subtotal give different totals (0.15 + 0.15 at 10 %: 0.04 vs 0.03). Finance bills per line.
cites: !701 (Ana, ruling), !603 (Bruno) · 2 distinct reviewers
bad:  var tax = Money.Round(subtotal * rate);
good: var tax = lines.Sum(l => Money.Round(l.Amount * rate));
```

**To enact:** change `status` to `enacted`, add your name and date in the table, and copy the block to `codes/`. That's a merge request like any other.

---

## Watching (below the bar: fewer than 2 MRs or 2 reviewers)

- "Prefer `record` for DTOs" — !518, Elena (author, not a reviewer) · 1 MR
- "Every acceptance criterion has at least one test" — !701, Carla · 1 MR · **the trial missed this one**; `prosecutor-tests` checks it but no guideline backs it yet
