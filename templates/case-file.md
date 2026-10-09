# Case file · <TICKET-ID> · MR !<number>
_built by `clerk` · <real | demo> mode_

asked:   <One sentence: what the ticket asks for>

ac:
- AC-1  <…>
- AC-2  <…>
<!-- If the ticket has none, write "ac: none provided". Never invent criteria. -->

diff:    <N> files · +<added> −<removed>
- `<path>`   +<a> −<r>   (new | modified | deleted)

touches: <money · data · tenancy · security · api · tests>
<!-- tags from .claude/skills/trial/reference/routing.md; they decide summary vs full trial -->

adrs:
- <ADR-NNNN> <title>
- _(<ADR-NNNN> skipped: Superseded)_

rules:   <`codes/<area>.md`, …>

humans:
<!-- Existing human review comments on the MR, verbatim. They are protected:
     no agent can dismiss them. Write "none yet (new MR)" if empty. -->
- <reviewer> · `<file:line>` · "<comment>"
