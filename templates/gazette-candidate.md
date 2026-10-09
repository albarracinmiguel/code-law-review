<!-- Two parts: one row in the table at the top of notes/gazette/candidates.md,
     and one detail block below it. -->

<!-- Table row -->
| C-<NN> | <GUIDELINE-ID> · <Rule title> | case law | doctrine | <N> MRs · <N> reviewers · changed after: <x/y> | ⏳ pending |

<!-- Status values:
     ⏳ pending                         waiting for a human
     ✅ enacted <YYYY-MM-DD> by <name>  copied to codes/
     ⚠️ CONFLICT with <ADR or rule>     contradicts a higher rule, never enacted
     ⚖️ SETTLED by <ADR>                an ADR already rejected it
     🚫 rejected by <name>: <reason>     a human said no -->

---

## C-<NN> · <pending | CONFLICT | SETTLED>

- **Proposed by:** `/case-law` | `/doctrine`
- **From:** <MR !n thread n (reviewer)> | <wiki page, exact sentence>
- **Signals:** <MRs> · <distinct reviewers> · <code changed after comment: x/y> · <ended in disagreement: yes/no>
- **Conflicts with / settled by:** <ADR-NNNN section, or "none">

```
## <GUIDELINE-ID> · <Short imperative title>
status: pending
default severity: <critical | major | optional | nit>
source: <case law | doctrine | ADR-NNNN>
rule: <One sentence>
why: <Why here>
cites: <!n, !n · N distinct reviewers>
bad: <smallest bad example, from the real diff>
good: <smallest good example>
```

**To enact:** set `status: enacted`, update the table row with your name and date, copy the block to `codes/<area>.md`. Do it in an MR.
