# Case Law Review - first-time setup
# Claude's remote tools can't write into .claude/, so the skills, agents and
# guidelines ship as _claude/. This script moves them into place and creates
# the git repo. Run once from this folder:  .\setup.ps1

$ErrorActionPreference = "Stop"
Set-Location $PSScriptRoot

if (Test-Path ".claude") {
    Write-Host ".claude already exists, nothing to move."
} else {
    Rename-Item -Path "_claude" -NewName ".claude"
    Write-Host "Moved _claude -> .claude"
}

if ((Get-Command git -ErrorAction SilentlyContinue) -and -not (Test-Path ".git")) {
    git init -b main | Out-Null
    git add -A
    git commit -m "Case Law Review: demo repo (ADRs, guidelines, skills, agents, sample case)" | Out-Null
    Write-Host "Git repo created with an initial commit."
}

Write-Host "Ready. Open this folder in Claude Code and try: /trial PROJ-1234"
