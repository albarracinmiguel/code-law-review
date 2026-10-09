# Data guidelines

## DATA-007 · Filter soft-deleted rows explicitly
status: enacted
default severity: major (critical when it changes a total, a list shown to users, or an export)
source: case law + ADR-0004
rule: Every query on a soft-deletable entity calls `.NotDeleted()`.
why: No global query filters in this repo (ADR-0004), so the filter must be visible at the call site.
cites: !412, !518, !603 · 2 distinct reviewers (Ana, Carla)
bad:
```csharp
var addons = await _db.Addons.Where(a => a.ReservationId == id).ToListAsync();
```
good:
```csharp
var addons = await _db.Addons.NotDeleted().Where(a => a.ReservationId == id).ToListAsync();
```

## DATA-008 · Scope every query by tenant
status: enacted
default severity: critical (aggravated: security)
source: doctrine (tenancy) + ADR-0004
rule: Every query on a tenant-scoped entity calls `.ForTenant(_tenant.TenantId)`, with the tenant taken from `ITenantContext`.
why: A missing tenant filter leaks data between customers.
cites: !518, !655 · 2 distinct reviewers · docs/domain/tenancy.md
bad:
```csharp
var invoice = await _db.Invoices.FirstOrDefaultAsync(i => i.Id == id);
```
good:
```csharp
var invoice = await _db.Invoices.NotDeleted().ForTenant(_tenant.TenantId)
    .FirstOrDefaultAsync(i => i.Id == id);
```

## DATA-011 · Children of a deleted parent count as deleted
status: enacted
default severity: major
source: doctrine (soft-delete)
rule: When reading children (add-ons, lines), also exclude those whose parent is deleted.
why: docs/domain/soft-delete.md, "Child records follow their parent".
cites: docs/domain/soft-delete.md · enacted from Gazette C-03
bad:
```csharp
_db.Addons.NotDeleted().Where(a => a.ReservationId == id)
```
good:
```csharp
_db.Addons.NotDeleted().Where(a => a.ReservationId == id && !a.Reservation.IsDeleted)
```
