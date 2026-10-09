# Trial record · <TICKET-ID> · MR !<number>

**Trial:** <summary | full>
**Reason:** <which routing trigger, or "default">
**Prosecutors:** <list>

---

## 1. Prosecution

| # | Prosecutor | Rule | File:line | Claim | Proposed |
|---|---|---|---|---|---|
| A-1 | <name> | <RULE-ID, AC-n, ADR-NNNN or TASTE> | `<file:line>` | <one sentence + evidence> | <severity> |

**Discarded by the court before the defense:**
- <A-n>: <no rule | no evidence | duplicate of A-m>

## 2. Defense
<!-- full trial only -->

| # | Verdict | Argument |
|---|---|---|
| A-1 | <REFUTED | SETTLED | NO DEFENSE | contested> | <file:line or ADR section> |

Closed: <A-n (refuted), A-m (settled)>. <Note any that repeat a human comment: those go to the judge anyway.>

## 3. Expert witness

| # | Repro | Output | Verdict |
|---|---|---|---|
| A-1 | <test, request or script> | <real output> | <REPRODUCED | NOT REPRODUCED> |

<List every critical NOT REPRODUCED → DISPUTED, "claimed: critical".>

## 4. Jury (<N> jurors)
<!-- full trial only -->

| # | Keep | Drop | Result |
|---|---|---|---|
| A-n | <k> | <d> | <posted as optional | posted as nit | not posted> |

## 5. To the judge

| Finding | Rule | Severity | State |
|---|---|---|---|
| F-n | <RULE-ID> | <claimed critical | critical | major | nit> | <DISPUTED | open> |

**Gate: <PASS | FAIL>** (<N critical open>)
