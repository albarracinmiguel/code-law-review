# Running the trial in CI

`gitlab-ci.yml` here is an example. Nothing in it depends on GitLab beyond the variable names: any CI that can run a job on merge requests works.

## Flow

1. MR opened (or updated) → `smart-review` job starts.
2. `claude -p "/trial <MR>"` runs Claude Code headless. The skill builds the case file, runs the trial and writes `notes/cases/<MR>/verdict.json`.
3. `scripts/post-verdict` posts one MR thread per finding (nits batched). **Not implemented in this demo.** About 40 lines against the GitLab API: `POST /projects/:id/merge_requests/:iid/discussions` with `position` for file:line.
4. `scripts/gate` reads `verdict.json` and exits 1 while any finding has `severity: critical` and `state: open`. **Not implemented in this demo.** Pseudocode:

   ```
   findings = read(verdict.json).findings
   open_critical = [f for f in findings if f.severity == "critical" and f.state == "open"]
   exit(1 if open_critical else 0)
   ```

5. The judge replies on each thread: `confirm` or `overrule: <reason>`. A new push re-runs the job; overruled findings stay closed.

## Choices to make before using it for real

| Question | Default here |
|---|---|
| Run on every push or only when the MR opens? | every MR event; switch to open-only if cost is a problem |
| Who can overrule a critical? | any reviewer, with a written reason |
| Where do verdicts live long-term? | CI artifacts; `/case-law` reads the overrule reasons from MR threads |
| Budget per MR | summary trial by default; full trial only on triggers (see `routing.md`) |
