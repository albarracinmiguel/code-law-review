---
name: <kebab-case-name>
description: <What it does and when to use it, in one or two sentences. Claude uses this line to decide when to load the skill.>
---

# /<name>

<!-- One paragraph: the job, and the one thing this skill refuses to do.
     Every skill in this process owns one job and refuses the others
     (e.g. /case-law proposes rules but never writes guidelines). -->

**You never <the refusal>.** Your only output is <file or place>.

## Inputs

- Real mode: <source, connector or CLI>
- Demo mode: <local stand-in>
- Current law: accepted ADRs and enacted guidelines

## Steps

### 1. <Verb>
<What to do, what to skip.>

### 2. <Verb>
<…>

### 3. Check against the law
<!-- Every skill that produces rules or findings checks: duplicates, CONFLICT with an ADR, SETTLED by an ADR. -->

### 4. Write
Use the template in `templates/<template>.md`.

## Output to the user
<!-- Short. Counts and paths, nothing about the internal process. -->
