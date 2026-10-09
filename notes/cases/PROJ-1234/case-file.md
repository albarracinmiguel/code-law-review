# Case file · PROJ-1234 · MR !701
_built by `clerk` · demo mode (sample/)_

asked:   Exclude soft-deleted add-ons from reservation totals, and add an endpoint
         that returns the active add-ons total.

ac:
- AC-1  Soft-deleted add-ons never count in the reservation total.
- AC-2  Restoring an add-on brings it back into the total.
- AC-3  `GET /reservations/{id}/addons/total` returns the sum of active add-ons for the caller's tenant.
- AC-4  Totals follow the billing rounding rules.

diff:    3 files · +50 −2
- `src/Billing/InvoiceService.cs`              +4 −2   (modified)
- `src/Api/AddonsController.cs`                +24     (new)
- `src/Billing.Tests/InvoiceServiceTests.cs`   +22     (new)

touches: money · data · tenancy · api · tests

adrs:
- ADR-0004 Data access via EF Core, explicit filters
- ADR-0012 Money is decimal, rounded away from zero
- _(ADR-0002 skipped: Superseded)_

rules:   `codes/data.md`, `money.md`, `api.md`, `tests.md`

humans:  none yet (new MR)
