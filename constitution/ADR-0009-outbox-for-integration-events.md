# ADR-0009: Integration events go through an outbox

- **Status:** Accepted
- **Date:** 2025-06-02

## Context

Services publish events (e.g. `InvoiceIssued`) to a message broker. Publishing directly after `SaveChanges` loses events when the process crashes between the two calls.

## Decision

Integration events are written to an `OutboxMessages` table **in the same transaction** as the business change. A background dispatcher publishes them and marks them sent.

Code must never call the broker client directly from a request handler or domain service.

## Alternatives considered

- **Publish after commit.** Rejected: events lost on crash.
- **Distributed transactions (2PC).** Rejected: not supported by the broker, heavy to operate.

## Consequences

- At-least-once delivery: consumers must be idempotent.
- A direct `IMessagePublisher.PublishAsync` call outside the dispatcher is an ADR violation.
