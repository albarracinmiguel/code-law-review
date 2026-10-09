# Harvested review threads (simulated)

What `/case-law` would pull from GitLab: one file per merged MR, human threads only, each comment with the diff hunk it was about and whether the code changed after it.

All MRs, people and code here are invented for the demo.

| MR | Title | Reviewers |
|---|---|---|
| [!412](mr-412.md) | Reservation list with add-ons | Ana, Bruno |
| [!518](mr-518.md) | Customer search endpoint | Carla, Ana |
| [!603](mr-603.md) | Invoice preview | Bruno, Carla |
| [!701](mr-701.md) | PROJ-1234, the MR from `sample/diff/` **after** its trial | Ana, Bruno, Carla (as judges) |

What `/case-law` did with them: [`runs/2025-10-01.md`](../runs/2025-10-01.md) (!412–!603) and [`runs/2025-10-15.md`](../runs/2025-10-15.md) (!701, the loop closing).
