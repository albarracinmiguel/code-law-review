# API and architecture guidelines

## API-002 · No business logic in controllers
status: enacted
default severity: major
source: case law
rule: Controllers map HTTP to an application service call and back. Calculations, queries and branching on business rules live in services.
why: Logic in controllers gets duplicated between endpoints and is not covered by service tests.
cites: !377, !412, !590 · 3 distinct reviewers
bad:
```csharp
[HttpGet("{id}/total")]
public async Task<decimal> Total(int id) =>
    (await _db.Addons.Where(a => a.ReservationId == id).ToListAsync()).Sum(a => a.Price);
```
good:
```csharp
[HttpGet("{id}/total")]
public Task<decimal> Total(int id) => _invoices.GetReservationTotalAsync(id);
```

## API-005 · Publish integration events only through the outbox
status: enacted
default severity: major
source: ADR-0009
rule: Never call `IMessagePublisher.PublishAsync` outside `OutboxDispatcher`. Add an `OutboxMessage` in the same `SaveChanges` instead.
why: Direct publishing loses events on crash. ADR-0009.
cites: ADR-0009
