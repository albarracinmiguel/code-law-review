---
name: case-law
description: Turn past merge request review threads into candidate rules for .claude/guidelines/. Use when asked to harvest, update or refresh case law. Never edits guidelines directly.
---

# /case-law

Mine human review comments from past merge requests and propose rules. A human enacts them.

**You never write to `.claude/guidelines/`.** Your only output is `notes/gazette/candidates.md`.

## Inputs

- Real mode: merged MRs from the last 90 days (GitLab API or `glab`), with their discussions.
- Demo mode: `notes/case-law/raw/*.md` (one file per MR, already harvested).
- Current law: `docs/adr/*.md` (only `Status: Accepted`) and `.claude/guidelines/*.md` (only `status: enacted`).

## Steps

### 1. Harvest
For each MR keep only **human** review threads. Drop:
- bot and system notes ("added 1 commit", CI messages, the generic review bot);
- comments by the MR author on their own code, unless they reply to a reviewer;
- pure approvals ("LGTM", "👍").

For each comment record: MR, reviewer, file:line, the diff hunk it refers to, the full thread, and whether the code **changed after** the comment in a later commit of the same MR.

### 2. Cluster
Group comments that state the same rule in different words. One cluster = one candidate rule. Write the rule as one imperative sentence.

### 3. Score
For each cluster:

| Signal | Why it matters |
|---|---|
| Recurrence (number of MRs) | A one-off is not a rule |
| Distinct reviewers | Protects against one person's habits becoming law |
| Code changed after the comment | The author accepted it |
| Thread ended in disagreement | Lowers confidence |

Do not compute a single magic score. Report the signals; the human decides.

**Minimum to propose:** 2 MRs and 2 distinct reviewers. Below that, list it under "Watching" instead.

### 4. Check against the law
Before proposing a candidate:
- If an enacted guideline already says it → add the new MRs to its `cites` (as a suggestion in the Gazette), don't create a duplicate.
- If it **contradicts an accepted ADR** → mark it `CONFLICT`, name the ADR, and do not propose it as a rule. Either a reviewer was wrong or the ADR needs revisiting; a human decides.
- If it suggests an alternative an ADR **rejected** → mark it `SETTLED`, name the ADR.

### 5. Write the Gazette
Append to `notes/gazette/candidates.md` using the format already in that file: ID `C-NN`, proposed guideline ID, rule, why, bad/good example taken from the real diff, cites, signals, status `pending`.

## Output to the user
A short summary: how many threads read, how many candidates proposed, how many conflicts or settled items, and the path of the Gazette. Nothing else.
