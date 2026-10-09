---
name: trial
description: Review a merge request as a trial - prosecutors accuse with evidence, the defense refutes, expert witnesses reproduce, a jury votes on taste, and a human judge rules. Use when asked to review an MR or a ticket's diff, e.g. "/trial 1234" or "/trial PROJ-1234".
---

# /trial

Run a code review as a trial. You are the **court**: you orchestrate, you don't accuse or defend. Every role is a subagent in `.claude/agents/`.

Argument: an MR number (real mode) or a ticket ID (demo mode, reads `sample/`).

References, read when you reach the step that needs them:
- `reference/case-file.md` — how to build the case file, per tracker
- `reference/routing.md` — summary vs full trial, which prosecutors
- `reference/severity.md` — levels and the merge gate
- `reference/verdict-schema.md` — the output format

## Rules of the trial (never break these)

1. **No proof, no finding.** An accusation without rule ID, `file:line` and evidence is discarded.
2. **A proven defect can't be voted away.** A `REPRODUCED` finding never goes to the jury.
3. **No benefit of the doubt.** Contested and not reproduced → `DISPUTED`, goes to the judge. Never silently dropped.
4. **Human comments are protected.** Existing human review comments on the MR must be answered. No agent can dismiss them.
5. **Aggravated matters.** Money, data and security findings are never downgraded by any agent.
6. **The law.** Only accepted ADRs and enacted guidelines can be cited. Superseded ADRs are repealed. Alternatives rejected in an ADR are settled.

## Steps

### 1. Case file
Spawn `clerk` with the MR or ticket. It writes `notes/cases/<ID>/case-file.md`. Read it.

### 2. Choose the trial
Use `reference/routing.md`:
- **Summary trial** (default): `prosecutor-generalist` → `expert-witness`. No defense, no jury.
- **Full trial**: when the diff touches money, data access, auth/tenancy, or is large. Specialist prosecutors routed by path, then defense, expert, jury.

Write the choice and the reason at the top of `notes/cases/<ID>/trial-record.md`.

### 3. Prosecution
Spawn the chosen prosecutors **in parallel**, each with the case file. Each returns accusations in the format of its agent file. Discard any accusation missing rule ID, `file:line` or evidence, and log that you discarded it.

Merge duplicates (same rule + same line) keeping the strongest evidence.

### 4. Defense (full trial only)
Spawn `defense` with all accusations. For each it returns `REFUTED` (with proof), `SETTLED` (citing an ADR) or `NO DEFENSE`.

A `REFUTED` or `SETTLED` accusation is closed **unless** it repeats a human reviewer's comment: then it stays open and goes to the judge with the defense's argument attached.

### 5. Expert witness
Spawn `expert-witness` with every accusation still open whose proposed severity is `critical` or `major`. It returns `REPRODUCED` or `NOT REPRODUCED` with the real output.

- `critical` + `NOT REPRODUCED` → downgrade to `DISPUTED`, keep the original severity as "claimed". (Rule 5: never silently lowered; the judge decides.)
- Contested by the defense + `NOT REPRODUCED` → `DISPUTED`.

### 6. Jury (full trial only)
Accusations tagged `TASTE` go to `jury`. Run **3 jurors in parallel** (odd number, tune later). Majority `KEEP` → post as `optional` or `nit`. Majority `DROP` → not posted. Never send a `REPRODUCED` finding to the jury.

### 7. Ruling (the judge is a human)
1. Write `notes/cases/<ID>/verdict.json` following `reference/verdict-schema.md`.
2. Post one MR thread per finding: severity, rule ID, `file:line`, evidence. Nits are batched into one thread.
3. Mark `DISPUTED` findings clearly; put them first.
4. **Never resolve a thread yourself.** The judge replies `confirm` or `overrule: <reason>`.
5. The gate fails while any `critical` thread is open. See `reference/severity.md`.

In demo mode, write the threads to `notes/cases/<ID>/mr-comments.md` instead of posting them.

## Output to the user
One line per finding (severity, rule, file:line), then the gate status. Nothing about the internal process unless asked.
