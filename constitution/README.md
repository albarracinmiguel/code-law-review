# Architecture Decision Records (the Constitution)

Only ADRs with `Status: Accepted` are law. `Superseded` means repealed: it stays here for history but can never be cited in a finding.

| ID | Title | Status |
|---|---|---|
| [ADR-0001](ADR-0001-record-architecture-decisions.md) | Record architecture decisions | Accepted |
| [ADR-0002](ADR-0002-money-as-double.md) | Represent money as double | **Superseded** by ADR-0012 |
| [ADR-0004](ADR-0004-data-access-ef-core.md) | Data access via EF Core, explicit filters | Accepted |
| [ADR-0009](ADR-0009-outbox-for-integration-events.md) | Integration events through an outbox | Accepted |
| [ADR-0012](ADR-0012-money-decimal-away-from-zero.md) | Money is decimal, rounded away from zero | Accepted |

## Format

Every ADR has: Status, Context, Decision, **Alternatives considered** (with why each was rejected) and Consequences.

The "Alternatives considered" section matters to the review: anything rejected there is **settled**. A prosecutor can't suggest it, and the defense can cite the ADR to close an accusation that does.
