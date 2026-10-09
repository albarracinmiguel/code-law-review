# ADR-0001: Record architecture decisions

- **Status:** Accepted
- **Date:** 2025-02-03

## Context

Big technical decisions get lost in chat threads and meetings. New people re-open them because they can't find the reasoning.

## Decision

We record significant architecture decisions as numbered Markdown files in `docs/adr/`, reviewed through a merge request like any code change.

An ADR is never edited after acceptance except to change its status. To change a decision, write a new ADR that supersedes the old one.

## Alternatives considered

- **Wiki pages.** Rejected: not versioned with the code and they drift silently.
- **No formal record.** Rejected: that's the problem we're solving.

## Consequences

- Decisions have an ID that reviews and agents can cite.
- Superseded ADRs stay in the repo, marked as such, so history is preserved.
