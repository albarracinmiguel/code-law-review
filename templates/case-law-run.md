# /<case-law | doctrine> run · <YYYY-MM-DD>
_input: <MRs !n–!m, last N days | wiki pages>_

<!-- The record of one run. Each section matches a step in the skill's SKILL.md.
     It's what lets a human check WHY a candidate reached the Gazette. -->

## 1. Harvest | Read

| MR | Thread | Who | File | Kept? | Why |
|---|---|---|---|---|---|
| !<n> | T<n> | <reviewer> | <file:line> | ✅ / ❌ | <human comment · judge ruling · author reply · bot · approval> |

<!-- Keep: human review comments, and human replies inside bot threads (confirm/overrule).
     Drop: bot text, CI notes, plain approvals, authors on their own code. -->

## 2. Cluster

| Cluster | Threads | Rule, as one sentence |
|---|---|---|
| K-<n> | !<n> T<n> · !<m> T<m> | <imperative sentence> |

## 3. Score

| Cluster | MRs | Distinct reviewers | Code changed after | Ended in disagreement |
|---|---|---|---|---|
| K-<n> | <n> | <n> (<names>) | <x/y> | <no | yes | withdrawn> |

Bar to propose: 2 MRs and 2 distinct reviewers.

## 4. Check against the law

| Cluster | Existing law | Result |
|---|---|---|
| K-<n> | <none | RULE-ID enacted | ADR-NNNN> | <→ candidate C-n | covered | SETTLED → C-n | CONFLICT → C-n | Watching> |

## 5. Written to the Gazette

- <C-n, C-m>
- Watching: <…>
- Citation suggestions: <RULE-ID: add !n>

**Summary to the user:** <N> threads read · <N> candidates · <N> settled · <N> conflicts · <N> covered.
