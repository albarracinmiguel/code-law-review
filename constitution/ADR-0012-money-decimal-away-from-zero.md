# ADR-0012: Money is decimal, rounded away from zero

- **Status:** Accepted
- **Date:** 2025-09-15
- **Supersedes:** [ADR-0002](ADR-0002-money-as-double.md)

## Context

ADR-0002 used `double` for money and invoices were off by a cent in some cases. Finance also expects **half-up** rounding on invoice lines (2.345 → 2.35), the way it's done on paper.

In .NET, `Math.Round(decimal, int)` uses `MidpointRounding.ToEven` by default ("banker's rounding": 2.345 → 2.34).

## Decision

1. Every monetary amount is `decimal`. Never `double` or `float`.
2. Every rounding of money uses `MidpointRounding.AwayFromZero`, through `Money.Round(value)` in `Shared.Billing`.
3. Rounding happens once per invoice line, never on intermediate values.

## Alternatives considered

- **Keep `double`, round at display time.** Rejected: errors accumulate before display.
- **Banker's rounding (`ToEven`).** Rejected: finance and customers expect half-up on invoices.
- **Integer cents (`long`).** Rejected: tax rates need more precision than cents mid-calculation.

## Consequences

- A bare `Math.Round(x, 2)` on money is a defect, even though it compiles and "looks right".
- See guideline `MONEY-003`.
