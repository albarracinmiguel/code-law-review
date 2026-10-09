<!-- Append to codes/<area>.md. IDs are never reused. -->

## <AREA>-<NNN> · <Short imperative title>
status: enacted
<!-- enacted | repealed (keep the entry, change only this line) -->
default severity: <critical | major | optional | nit>
<!-- money, data and security rules: critical or major, never lower (aggravated) -->
source: <case law | doctrine | ADR-NNNN> <!-- can be several: "case law + ADR-0004" -->
rule: <One sentence. What must be true. Testable against a line of code.>
why: <Why this repo does it this way. Cite the ADR when there is one.>
cites: <!n, !n, !n · N distinct reviewers> <!-- or the ADR / wiki page; a rule with no source is not enacted -->
bad:
```<language>
<smallest example that breaks it>
```
good:
```<language>
<smallest example that follows it>
```
