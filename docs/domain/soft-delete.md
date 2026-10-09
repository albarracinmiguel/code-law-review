# Soft delete (wiki)

_Last edited: April 2025 · Owner: Platform team_

Most business entities are never physically deleted. Deleting sets `IsDeleted = true` and `DeletedAt = now`.

## Rules

- Deleted records **never** appear in lists, searches, totals or exports.
- Deleted records **can** be restored by an admin. Restoring sets `IsDeleted = false`; the record must then count again everywhere (totals included).
- Child records follow their parent: an add-on of a deleted reservation is treated as deleted, even if its own flag is false.
- Reports for auditors are the only place where deleted records may appear, and they are labelled as deleted.

## Entities that are soft-deletable

Customer, Reservation, Addon, Invoice, InvoiceLine, PriceRule.
