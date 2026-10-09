# MR comment templates

One thread per finding. Nits batched in one thread. Disputed findings posted first.

---

## Summary (always first)

```markdown
**Smart Review · summary**
<Summary | Full> trial (<reason>) · <N> findings · **gate: <PASS | FAIL>** (<N> critical open, <N> disputed)
```

## Disputed

```markdown
### ⚖️ DISPUTED · claimed <severity> · <RULE-ID> · `<file:line>`
<What the prosecutor claims, one or two sentences.>
**Defense:** <the argument>
**Expert:** NOT REPRODUCED. <what was tried>
**Judge:** `confirm` · `overrule: <reason>`
```

## Critical

```markdown
### 🔴 CRITICAL · <RULE-ID> · <AC-n if any> · `<file:line>`
<What is wrong and what to do instead, one or two sentences.>
**Expert:** <repro> → `<actual>`, expected `<expected>`.
**Judge:** `confirm` · `overrule: <reason>`
```

## Major

```markdown
### 🟠 MAJOR · <RULE-ID> · `<file:line>`
<What is wrong and what to do instead.> Reply required.
```

## Optional

```markdown
### 🔵 OPTIONAL · <RULE-ID or "judgment call"> · `<file:line>`
<Suggestion.> Non-blocking. Jury: <k> keep / <d> drop.
```

## Nits (one thread)

```markdown
### ⚪ Nits (<N>)
- <RULE-ID> · `<file:line>` · <one line>
- <RULE-ID> · `<file:line>` · <one line>
```

---

## Judge replies

<!-- The only replies the gate understands. The reason in an overrule is harvested by /case-law. -->

```
confirm
```

```
confirm. <optional explanation, e.g. a counterexample>
```

```
overrule: <reason, mandatory>
```
