# Case Law Review

> Smart Review Agent: case law for code.

A **demo repository** for a code-review process built as Claude Code skills and agents. Everything is Markdown. There is no real application here: the C# under `sample/` is just enough code to have something to review.

The idea in one line: **a review that works like a courtroom.** Rules come from our own past reviews, our ADRs and our domain docs. Every finding has to bring evidence, and a human makes the final call.

## First time

Run `setup.ps1` once from this folder (PowerShell). It renames `_claude/` to `.claude/` (the files were delivered under a different name) and creates the git repo with an initial commit.

```powershell
cd D:\code\case-law-review
powershell -ExecutionPolicy Bypass -File .\setup.ps1
```

---

## The cast

| Role | What it is in this repo | Type | ES reference |
|---|---|---|---|
| Case law | `/case-law` mines past MR review threads | Skill | Jurisprudencia |
| Doctrine | `/doctrine` extracts invariants from the wiki (`docs/domain/`) | Skill | Doctrina |
| Constitution | Accepted ADRs in `constitution/` | Artifact | Constitución |
| Codes | Approved rules in `codes/` | Artifact | Los Códigos |
| Official Gazette | `notes/gazette/candidates.md`: rules waiting for human approval | Artifact | Boletín Oficial |
| Case file | Ticket + diff + relevant ADRs, built per MR | Artifact | Expediente |
| Clerk | Builds the case file (cheap model, no judgment) | Agent | Secretario |
| Prosecution | Specialist agents that accuse, with evidence | Agents | Fiscalía |
| Defense | Refutes each accusation, or says "no defense" | Agent | Defensoría |
| Expert witness | Reproduces what is left: tests, HTTP calls, scripts | Agent | Perito |
| Jury | Votes only on taste (naming, style) | Agent (×N) | Jurado |
| Judge | **You**, the human reviewer on the MR | Human | Juez |
| Trial | `/trial` orchestrates all of the above | Skill | Juicio |

## Hierarchy of law

```
            Constitution  (constitution/, status: Accepted)
         Codes  (codes/, enacted by a human)
   Case law + Doctrine  (interpret the rules above, never contradict them)
```

- **Superseded ADR = repealed.** It cannot be cited. See `ADR-0002`.
- **Rejected alternatives in an ADR are settled** (res judicata). No finding can reopen them. See the "Alternatives" section of `ADR-0004`.
- **Conflict = reported, not enacted.** See candidate `C-05` in the Gazette.

## Rules of the trial

1. No proof, no finding.
2. A proven defect can't be voted away.
3. No benefit of the doubt: disputed findings go to the judge.
4. Human review comments are never silently dismissed.
5. Money, data and security are aggravated: never downgraded.

## Severity and the merge gate

| Level | Meaning | Gate | Evidence needed |
|---|---|---|---|
| Critical | Breaks data, money, security or an acceptance criterion | Blocks the merge | Reproduced by the expert witness |
| Major | Breaks a guideline or an ADR | Reply required | Rule ID + file:line |
| Optional | A better way, judgment call | Non-blocking | Jury majority |
| Nit | Naming, style, formatting | Non-blocking, batched | Jury majority |

---

## Repository map

```
.claude/
  skills/
    case-law/SKILL.md          ← Skill 1: old review threads → candidate rules
    doctrine/SKILL.md          ← Skill 2: wiki → candidate invariants
    trial/SKILL.md             ← Skill 3: the review itself
    trial/reference/           ← case file, routing, severity, verdict schema
  agents/
    clerk.md                   ← builds the case file
    prosecutor-generalist.md   ← summary trial only
    prosecutor-data.md
    prosecutor-money.md
    prosecutor-security.md
    prosecutor-architecture.md ← ADRs
    prosecutor-tests.md
    defense.md
    expert-witness.md
    jury.md
constitution/                  ← the Constitution: ADRs
codes/                         ← the Codes: rules in force (enacted)
docs/
  domain/                      ← simulated wiki export (doctrine source)
notes/
  case-law/raw/                ← harvested MR threads (fake, for the demo)
  case-law/runs/               ← what /case-law did, step by step
  doctrine/runs/               ← what /doctrine did, step by step
  gazette/candidates.md        ← waiting for approval
  cases/PROJ-1234/             ← one complete trial, start to finish
sample/
  src/                         ← tiny fake C# code
  diff/PROJ-1234.diff          ← the MR under review
  tickets/PROJ-1234.md         ← the ticket (tracker-agnostic)
examples/ci/gitlab-ci.yml      ← how it would run on every MR
templates/                     ← one template per artifact (ADR, ticket, case file, verdict, MR comments…)
```

## How to demo it (about 10 minutes)

1. **The law.** Open `constitution/ADR-0004-data-access-ef-core.md` (look at "Alternatives") and `codes/data.md`.
2. **Where rules come from.** Open `notes/case-law/raw/mr-412.md`, then the run `notes/case-law/runs/2025-10-01.md` (harvest → cluster → score → check against the law), then `notes/gazette/candidates.md`. The same rule shows up across MRs and reviewers, gets proposed, and a human enacts it. Also look at the conflict (C-05) and the settled items (C-06, C-07).
3. **The trial.** Open `.claude/skills/trial/SKILL.md` and walk the steps.
4. **One real case.** Go through `notes/cases/PROJ-1234/` in order:
   `case-file.md` → `trial-record.md` → `verdict.json` → `mr-comments.md`.
5. **The loop closes.** `notes/case-law/raw/mr-701.md` is the same MR after the judges ruled, and `notes/case-law/runs/2025-10-15.md` turns a ruling into a new candidate (C-09) and spots something the trial missed.
6. **Run it yourself** (optional). In Claude Code, from this folder:
   ```
   /trial PROJ-1234
   ```
   It reads `sample/diff/PROJ-1234.diff` and `sample/tickets/PROJ-1234.md` instead of a real MR, as explained in `.claude/skills/trial/reference/case-file.md`.

## What is real and what is simulated

| Real | Simulated |
|---|---|
| Skill and agent files, in Claude Code's format | GitLab, the ticket tracker and the wiki |
| The process: steps, rules, severities, gate | MR numbers, reviewers' comments, ticket IDs |
| The structure of every artifact (see `templates/`) | `sample/` code and the trial outcome in `notes/cases/` |

No metrics here on purpose. Measuring comes with the real demo: replay past MRs through (A) the current generic bot, (B) generic bot + ADRs, (C) `/trial`, and compare findings caught, false positives and cost per MR.
