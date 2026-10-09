# ADR-0002: Represent money as double

- **Status:** Superseded by [ADR-0012](ADR-0012-money-decimal-away-from-zero.md)
- **Date:** 2025-02-10

> **Repealed.** This ADR is kept for history only. It must not be cited in any finding or defense.

## Context

We needed a numeric type for prices and totals in the first billing prototype.

## Decision

Use `double` for all monetary amounts.

## Why it was superseded

Binary floating point can't represent most decimal fractions exactly, which produced off-by-one-cent totals in invoices. See ADR-0012.
