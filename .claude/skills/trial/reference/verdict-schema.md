# verdict.json

One file per trial at `notes/cases/<ID>/verdict.json`. The CI scripts read it to post comments and run the gate.

```json
{
  "case": "PROJ-1234",
  "mr": 701,
  "trial": "full | summary",
  "reason": "why this trial type",
  "gate": "PASS | FAIL",
  "findings": [
    {
      "id": "F-1",
      "rule": "DATA-007",
      "severity": "critical | major | optional | nit",
      "state": "open | DISPUTED | SETTLED",
      "claimed_severity": "only when state is DISPUTED",
      "file": "src/Billing/InvoiceService.cs",
      "line": 42,
      "summary": "one sentence",
      "evidence": "code path, failing input or expert output",
      "prosecutor": "prosecutor-data",
      "defense": "REFUTED | SETTLED | NO DEFENSE | null",
      "expert": "REPRODUCED | NOT REPRODUCED | null",
      "jury": { "keep": 2, "drop": 1 }
    }
  ],
  "discarded": [
    { "prosecutor": "…", "reason": "no evidence | settled by ADR-XXXX | duplicate" }
  ]
}
```

`discarded` is kept on purpose: it's how we tune prosecutors later (what they accuse that never survives).
