# sample/

Just enough fake C# to have something to review. It doesn't compile on its own (no project files, no `DbContext`), and that's fine: the trial reads it, it doesn't build it.

| Path | What it is |
|---|---|
| `tickets/PROJ-1234.md` | The ticket, as any tracker would have it |
| `diff/PROJ-1234.diff` | The MR under review (`!701`) |
| `src/` | The files **after** the MR, so line numbers in findings point somewhere real |

The MR contains, on purpose:

| Planted defect | Rule | Expected outcome |
|---|---|---|
| Deleted add-ons summed into the total | DATA-007 / AC-1 | critical, reproduced |
| `Math.Round(x, 2)` on tax | MONEY-003 | critical, reproduced |
| Tenant taken from the query string | DATA-008 | critical, reproduced |
| Sum calculated in the controller | API-002 | major |
| Test expectation computed by the code under test | TEST-006 | major |
| Test named `Test1` | TEST-001 | nit (jury) |
| Tax on subtotal instead of per line | MONEY-003 | **disputed** → judge |

And traps the trial should **not** fall into:

| Trap | Why it's not a finding |
|---|---|
| "Use a global query filter instead" | Settled: ADR-0004 rejected it |
| "Endpoint has no `[Authorize]`" | Refuted: it's on the controller class |
| "Consider caching the total" | No evidence: discarded |
