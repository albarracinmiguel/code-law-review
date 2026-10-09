# Tenancy (wiki)

_Last edited: March 2025 · Owner: Platform team_

Each customer company is a **tenant**. All tenant data shares the same database; rows are separated by `TenantId`.

## Rules

- A request can only read or write rows of its own tenant. The tenant comes from the authenticated token (`ITenantContext.TenantId`), **never** from the request body or query string.
- Background jobs run per tenant and must set the tenant context explicitly.
- Cross-tenant reads exist only in the internal admin API, behind the `PlatformAdmin` policy.

## Why it matters

A missing tenant filter is a data leak between customers. Treat it as a security defect, not a style issue.
