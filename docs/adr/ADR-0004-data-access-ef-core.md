# ADR-0004: Data access via EF Core, with explicit filters

- **Status:** Accepted
- **Date:** 2025-03-18

## Context

Most entities are **soft-deleted** (`IsDeleted`) and **multi-tenant** (`TenantId`). Every read must exclude deleted rows and stay inside the caller's tenant. We need one way to access data that makes those two filters hard to forget and easy to review.

## Decision

1. All data access goes through EF Core `DbContext` in the `*.Data` projects.
2. Soft-delete and tenant filters are written **explicitly** in each query, using the extension methods `.NotDeleted()` and `.ForTenant(tenantId)` from `Shared.Data`.
3. Repositories never return `IQueryable` outside the data layer.

## Alternatives considered

- **EF Core global query filters (`HasQueryFilter`).** Rejected. Filters become invisible at the call site, so reviewers can't see them, and `IgnoreQueryFilters()` is easy to add by accident. We prefer a visible filter on every query, even if it's more verbose.
- **Dapper with hand-written SQL.** Rejected. Two data-access styles in one codebase, and the tenant filter would live in every SQL string.
- **Stored procedures.** Rejected. Logic moves out of the reviewed codebase.

> These alternatives are **settled**. A review finding must not suggest them.

## Consequences

- Every query on a soft-deletable or tenant-scoped entity shows its filters. A query without them is a defect.
- Slightly more verbose queries. Accepted cost.
- See guideline `DATA-007` and `DATA-008` for how this is reviewed.
