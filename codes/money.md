# Money guidelines

## MONEY-003 · Round money away from zero, once per line
status: enacted
default severity: critical (aggravated: money)
source: ADR-0012 + case law
rule: Round monetary values only with `Money.Round(value)` (which uses `MidpointRounding.AwayFromZero`), once per invoice line.
why: `Math.Round(decimal, int)` defaults to banker's rounding (`ToEven`). Finance expects half-up. ADR-0012.
cites: !431, !603, !640 · 3 distinct reviewers
bad:
```csharp
var tax = Math.Round(subtotal * rate, 2);          // 2.345 → 2.34
```
good:
```csharp
var tax = Money.Round(subtotal * rate);            // 2.345 → 2.35
```

## MONEY-004 · Never use double or float for money
status: enacted
default severity: critical (aggravated: money)
source: ADR-0012
rule: Monetary fields, parameters and locals are `decimal`.
why: Binary floating point can't represent most cents exactly. ADR-0002 was repealed for this reason.
cites: ADR-0012
bad: `double price = 19.99;`
good: `decimal price = 19.99m;`
