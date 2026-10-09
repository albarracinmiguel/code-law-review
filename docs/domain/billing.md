# Billing (wiki)

_Last edited: November 2024 · Owner: Billing team_

> Note for the demo: this page predates ADR-0012 on purpose. It shows how `/doctrine` handles an outdated wiki page.

## Invoice totals

- Invoice total = sum of active invoice lines + sum of active add-ons + tax.
- Tax is calculated per line: `line amount × tax rate`.
- Amounts are stored as `double` and rounded to 2 decimals when displayed.   ← outdated: contradicts ADR-0012

## Add-ons

- Add-ons are optional extras attached to a reservation (e.g. electricity, extra parking).
- A soft-deleted add-on must not be billed.
- Restoring an add-on before the invoice is issued brings it back into the total.
