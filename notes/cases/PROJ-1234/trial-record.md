# Trial record · PROJ-1234 · MR !701

**Trial:** full
**Reason:** `touches` includes money, data and tenancy.
**Prosecutors:** money (always), security (always), data, architecture, tests.

> Demo: this record is a simulated run, written to show what each role produces. Expert outputs are marked SIMULATED.

---

## 1. Prosecution

| # | Prosecutor | Rule | File:line | Claim | Proposed |
|---|---|---|---|---|---|
| A-1 | data | DATA-007, AC-1 | `InvoiceService.cs:24` | Add-ons query has no `.NotDeleted()`: deleted add-ons are summed into the total. The ticket's main bug is still there. | critical |
| A-2 | money | MONEY-003, AC-4 | `InvoiceService.cs:28` | `Math.Round(x, 2)` uses banker's rounding. Input: subtotal 23.45, rate 0.10 → 2.34, expected 2.35. | critical |
| A-3 | security | DATA-008, AC-3 | `AddonsController.cs:17` | `tenantId` comes from the query string. A user of tenant 1 can read tenant 2 totals with `?tenantId=2`. | critical |
| A-4 | architecture | API-002 | `AddonsController.cs:22` | The sum is calculated in the controller instead of a service. | major |
| A-5 | tests | TEST-006 | `InvoiceServiceTests.cs:19` | `expected` is computed by the method under test, so the test can't fail. It passes today with the AC-1 bug present. | major |
| A-6 | tests | TEST-001 · TASTE | `InvoiceServiceTests.cs:9` | Test named `Test1`. | nit |
| A-7 | money | MONEY-003 | `InvoiceService.cs:28` | Tax is calculated on the subtotal, not per line. ADR-0012 says round once per line. | critical |
| A-8 | architecture | TASTE | `AddonsController.cs:17` | `GetAddonsTotal` should be `GetActiveAddonsTotal`. | nit |
| A-9 | data | — | `InvoiceService.cs:24` | Use a global query filter (`HasQueryFilter`) so this can't happen again. | major |
| A-10 | security | — | `AddonsController.cs:16` | New endpoint has no `[Authorize]`. | critical |
| A-11 | architecture | — | `InvoiceService.cs:19` | Consider caching the reservation total. | optional |

**Discarded by the court before the defense:**
- A-11: no rule and no evidence. _No proof, no finding._

## 2. Defense

| # | Verdict | Argument |
|---|---|---|
| A-1 | NO DEFENSE | Compared with `AddonQueries.cs:18`, which filters correctly, this query doesn't. |
| A-2 | NO DEFENSE | — |
| A-3 | NO DEFENSE | — |
| A-4 | NO DEFENSE | — |
| A-5 | NO DEFENSE | — |
| A-7 | **contested** | Tax is rounded exactly once, which is what ADR-0012 point 3 forbids breaking ("never on intermediate values"). With a single tax rate, per-line and subtotal tax should match. |
| A-9 | **SETTLED** | ADR-0004, Alternatives considered: "EF Core global query filters. Rejected." |
| A-10 | **REFUTED** | `[Authorize(Policy = "TenantUser")]` is on the controller class, `AddonsController.cs:8`, and applies to every action. |

Closed: A-9 (settled), A-10 (refuted). Neither repeats a human comment, so they're closed without going to the judge.

## 3. Expert witness

| # | Repro | Output | Verdict |
|---|---|---|---|
| A-1 | Seed 2 lines × 50.00, 1 deleted add-on 20.00, tax 0 %. Call `GetReservationTotalAsync(1)`. | `120.00` (expected `100.00`) · SIMULATED | **REPRODUCED** |
| A-2 | `Math.Round(23.45m * 0.10m, 2)` vs `Money.Round(...)` | `2.34` vs `2.35` · SIMULATED | **REPRODUCED** |
| A-3 | `GET /reservations/7/addons/total?tenantId=2` with a tenant-1 token | `200 OK · 340.00` (tenant 2 data) · SIMULATED | **REPRODUCED** |
| A-4 | n/a (structural, cited rule is enough for major) | — | — |
| A-5 | Run the test against the current code (with the A-1 bug) | `Passed` · SIMULATED | **REPRODUCED** (the test can't catch the bug) |
| A-7 | Ticket data (2 × 50.00 at 10 %) and 20 random line sets | per-line tax = subtotal tax in all runs · SIMULATED | **NOT REPRODUCED** |

A-7 was claimed critical, contested by the defense and not reproduced → **DISPUTED**, goes to the judge with "claimed: critical". (Aggravated: never silently downgraded.)

## 4. Jury (3 jurors)

| # | Keep | Drop | Result |
|---|---|---|---|
| A-6 `Test1` | 3 | 0 | posted as **nit** (TEST-001 is enacted) |
| A-8 rename | 1 | 2 | **not posted** |

## 5. To the judge

| Finding | Rule | Severity | State |
|---|---|---|---|
| F-7 | MONEY-003 | claimed critical | **DISPUTED** |
| F-1 | DATA-007, AC-1 | critical | open |
| F-2 | MONEY-003, AC-4 | critical | open |
| F-3 | DATA-008, AC-3 | critical | open |
| F-4 | API-002 | major | open |
| F-5 | TEST-006 | major | open |
| F-6 | TEST-001 | nit | open |

**Gate: FAIL** (3 open critical).
