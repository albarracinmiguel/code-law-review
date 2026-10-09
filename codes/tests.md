# Test guidelines

## TEST-001 · One behavior per test, named after it
status: enacted
default severity: nit
source: case law
rule: Each test checks one behavior. The name says the behavior: `Method_Condition_ExpectedResult`.
why: When a test fails, its name should say what broke.
cites: !402, !518, !603, !640 · 4 distinct reviewers
bad: `public void Test1()`
good: `public void GetTotal_WithDeletedAddon_ExcludesIt()`

## TEST-004 · A bug fix ships with a regression test that failed first
status: enacted
default severity: major
source: case law
rule: A fix for a reported bug includes a test that reproduces it. The MR description says the test failed before the fix.
why: Without it we can't tell the fix works, or notice when it regresses.
cites: !431, !590, !655 · 3 distinct reviewers

## TEST-006 · Fixtures must not agree with the code by construction
status: enacted
default severity: major
source: case law
rule: Expected values in a test are computed by hand or from the spec, never by calling the code under test.
why: A fixture that reuses the production calculation can't catch a wrong calculation.
cites: !603, !640 · 2 distinct reviewers
bad: `var expected = _calculator.GetTotal(lines);`
good: `var expected = 100.00m; // 2 lines × 50.00, no tax`
