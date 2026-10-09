# MR !701 · what gets posted

In real mode each block below is one thread on the MR. In demo mode `/trial` writes them here.

---

**Smart Review · summary**
Full trial (touches money, data, tenancy) · 7 findings · **gate: FAIL** (3 critical open, 1 disputed)

---

### ⚖️ DISPUTED · claimed critical · MONEY-003 · `InvoiceService.cs:28`
Tax is calculated on the subtotal instead of per line. ADR-0012 says rounding happens once per invoice line.
**Defense:** tax is still rounded exactly once, and with one tax rate per-line and subtotal tax should match.
**Expert:** NOT REPRODUCED with the ticket data and 20 random line sets.
**Judge:** `confirm` · `overrule: <reason>`

> **Ana (judge):** confirm. Lines 0.15 + 0.15 at 10 % give 0.04 per line vs 0.03 on the subtotal. Same rate doesn't mean same rounding. Please compute tax per line.
> _This reply will be harvested by `/case-law` as a precedent for MONEY-003._

---

### 🔴 CRITICAL · DATA-007 · AC-1 · `InvoiceService.cs:24`
The add-ons query has no `.NotDeleted()`, so deleted add-ons are still summed. This is the bug the ticket asks to fix.
**Expert:** 2 lines × 50.00 + 1 deleted add-on 20.00 → `120.00`, expected `100.00`.
**Judge:** `confirm` · `overrule: <reason>`

---

### 🔴 CRITICAL · MONEY-003 · AC-4 · `InvoiceService.cs:28`
`Math.Round(x, 2)` uses banker's rounding. Invoices round away from zero (ADR-0012). Use `Money.Round`.
**Expert:** `Math.Round(23.45m * 0.10m, 2)` = `2.34`, `Money.Round` = `2.35`.
**Judge:** `confirm` · `overrule: <reason>`

---

### 🔴 CRITICAL · DATA-008 · AC-3 · `AddonsController.cs:17`
`tenantId` comes from the query string. Take it from `ITenantContext`.
**Expert:** `GET /reservations/7/addons/total?tenantId=2` with a tenant-1 token → `200 OK`, tenant 2 data.
**Judge:** `confirm` · `overrule: <reason>`

---

### 🟠 MAJOR · API-002 · `AddonsController.cs:22`
The sum is calculated in the controller. Move it to `IInvoiceService` and call it from here. Reply required.

---

### 🟠 MAJOR · TEST-006 · `InvoiceServiceTests.cs:19`
`expected` comes from the method under test, so this test can't fail. It passes today even with the DATA-007 bug. Use `expected = 100.00m`. Reply required.

---

### ⚪ Nits (1)
- TEST-001 · `InvoiceServiceTests.cs:9` · `Test1` → `GetReservationTotal_WithDeletedAddon_ExcludesIt`
