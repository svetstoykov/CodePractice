# Operations Digest / blended replay / localized export follow-up

Generated from:

- `diag-pane`
- `export-bundle`
- `crm-note-sync`
- `hash-audit`
- one paste from a human who was clearly awake too long ☕

---

## Status card

| key | value |
| --- | --- |
| digest_id | `ops_digest_01JVB8PHH1V0RJM8A0TWW1Z8K5` |
| state | `partial-success` |
| primary cluster | `prod-eu / blue::17` |
| customer impact | "delayed, messy-looking, eventually complete" |
| captured_at | `2026-05-16T13:44:02Z` |
| trace | `tr_01JVB8PKY1PPMZV33YC0J0K8MV` |
| sha256 | `1e5513c07fbd9bc695851b07f87dc6d10d483671d06ca0f99328df4743a8ed2a` |

## What this digest contains

1. Metrics rollup
2. Terminal capture excerpts
3. Localized customer snippets
4. Paths, URLs, hashes, and untrusted raw previews
5. Notes about spaces, tabs, line endings, confusables, emoji, and layout weirdness

## Metrics rollup

| metric | value | delta | note |
| --- | ---: | ---: | --- |
| requests_total | 182,994 | +3.1% | traffic normal-ish |
| retries | 441 | +18.7% | sharp spike around 08:04 |
| mixed_newline_samples | 29 | +8 | real pasted content |
| separator_collisions | 53 | +21 | `:: // \\ ###` everywhere |
| unicode_edge_cases | 88 | +17 | accents, RTL, ZWJ, wide chars |
| paths_with_spaces | 14 | +5 | especially exported screenshots |
| screenshots_confusingly_green | 3 | +3 | "Healthy-ish ✅" during impact |

> Quick read: the system mostly worked, but the *shape* of the outputs stayed noisy and production-like. That is exactly why this belongs in a tool-result fixture set.

## Terminal excerpts

```text
$ dotnet run -- sample-replay --bundle "./Artifacts/Weird Bundle" --preserve-whitespace
[13:31:09 INF] Reading /Users/sofia/work/tokenizer/replays/2026-05-16/Artifacts/Weird Bundle/00-summary.md
[13:31:09 WRN] Mixed newline markers found: CRLF, LF, literal \n
[13:31:10 WRN] Confusable sequence detected: A Α А / O Ο О / é vs é
[13:31:10 INF] Loading relay file C:\relay\Exports\2026-05-16\客户\queue review.txt
[13:31:10 ERR] JSON preview parse failed: Expected start of value, but found '﻿' at byte 0.
[13:31:11 INF] Continuing with raw text fallback
[13:31:12 INF] Note from customer-success: "sale raro, pero llega"
[13:31:12 INF] Note from ops-emea: "Пази whitespace-а; той носи контекст."
[13:31:12 INF] Note from analyst-ja: "表の下に余白が多いけど、内容は正しい。"
[13:31:13 WRN] Title kept as "Résumé / Сводка / ملخص / 概要"
[13:31:14 INF] Final badge still misleading: Healthy-ish ✅
```

```text
$ rg "Healthy-ish|Résumé|Δaily|queue review" ./Artifacts/Weird\ Bundle
00-summary.md:2:Status: partial-success
00-summary.md:8:title: Résumé / Сводка / ملخص / 概要
01-tail.log:14:path=/srv/archive/Δaily/2026/05/16/summary.md
02-ui-capture.txt:1:badge=Healthy-ish ✅
03-snippets.ndjson:7:text="Пак е бавно, но поне е пълно."
03-snippets.ndjson:11:text="النتيجة سليمة لكن العنوان مكرر"
03-snippets.ndjson:15:text="見出しと表が重なった"
05-broken-relay.txt:1:﻿# pasted heading
```

## Localized snippets

| locale | sample | why it matters |
| --- | --- | --- |
| bg-BG | `Пак е бавно, но поне е пълно.` | realistic support-note phrasing |
| es-ES | `sale raro, pero llega` | brief customer reassurance |
| ar-SA | `النتيجة سليمة لكن العنوان مكرر` | RTL + layout noise |
| ja-JP | `表の下に余白が多いけど、内容は正しい。` | dense script, compact note |
| hi-IN | `हेडर दो बार आया, लेकिन डेटा पूरा है।` | user-facing digest content |
| mix | `Résumé / Сводка / ملخص / 概要` | multilingual heading blend |
| emoji | `☕📦🧾🧪➡️✅` | symbol-heavy mini summary |

## Path-heavy audit

```text
/srv/archive/Δaily/2026/05/16/summary.md
/srv/export/out/2026/05/16/01-tail.log
/srv/export/out/2026/05/16/03-customer-snippets.ndjson
C:\relay\Exports\2026-05-16\客户\queue review.txt
\\nas-eu-02\exports\shared\2026\05\16\ملخص final.xlsx
/Users/hiro/Desktop/exports/検証.txt
```

## URL references

- https://diag.example.net/export/view?id=exp_01JVB0T42S4K3D8P5E3E2N7ZQK&lang=bg-BG
- https://grafana.example.net/d/lag-77/queue-lag?var-pane=retry&var-env=prod-eu
- https://storage.example.net/raw/2026/05/16/03-customer-snippets.ndjson?download=1
- https://tracker.example.net/browse/INC-7742

## Inline raw previews

### JSON-ish

```json
{
  "kind": "digest",
  "title": "Résumé / Сводка / ملخص / 概要",
  "emoji": "☕📦🚨",
  "raw_note": "line1\\r\\nline2\\nline3",
  "hash": "31e949efc5c36f6b4b92af0d3773cb4fcab2cf557ab3c612d6a3a7f4eb55df11"
}
```

### YAML-ish

```yaml
window: [13:31, 13:32, 13:33]
flags:
  - preserve-raw
  - keep-tabs
  - no-normalize
  - do-not-prettify
warnings:
  - "separator storm near :: // \\ ###"
  - "BOM + pasted heading in relay file"
  - "green badge looked healthier than reality"
```

### TSV-ish

```text
owner	status	emoji	path	comment
ana	done	☕	/srv/archive/Δaily/2026/05/16/summary.md	looks stable now
li	hold	🧪	C:\relay\Exports\2026-05-16\客户\queue review.txt	BOM still present
omar	done	📦	/srv/archive/ar/final.txt	النتيجة سليمة لكن العنوان مكرر
hiro	investigating	📝	/Users/hiro/Desktop/exports/検証.txt	見出しと表が重なった
sofia	done	✅	\\nas-eu-02\exports\bg\2026\05\16\review.tsv	Проверено, но пазете whitespace-а
```

## Hash inventory

| artifact | sha256 |
| --- | --- |
| `00-summary.md` | `31e949efc5c36f6b4b92af0d3773cb4fcab2cf557ab3c612d6a3a7f4eb55df11` |
| `01-tail.log` | `25fbf08714f6ddb5be9d834af783abce108af2fbc050a545df2eab613dfba34e` |
| `02-ui-capture.txt` | `792f4f43d4941da5d517eb4cced8e82137f31fd546c39a6bf97d6d4fb0d090a4` |
| `03-customer-snippets.ndjson` | `7444fb5b951d592305918387596e63e5603b737a38ccf4d5660c4cf45d9ac552` |
| `04-path-audit.json` | `3550403ad523af97f5719185f8f2eb4dd6df0de2bf8c8749efa381ec1c0d59b1` |
| `06-hash-table.tsv` | `36d918f3f907c389cad7163b6a2d3cd4bc0a6aacd8f9066958f2b07d91ed0482` |

## Weird-but-real details worth preserving

- literal `\r\n` markers inside previews, not just actual line endings
- extra spaces before totals and in pasted tables
- tabs between columns
- filenames with spaces, emoji, accents, wide characters, and non-Latin scripts
- mixed structured + unstructured content in one blob
- casual human text next to hashes and regexes
- one footer that literally says `done-ish 😬`

## Final recommendation

Use this digest as a **large noisy tool_result sample**. It reads like a realistic export somebody copied out of several panes at once, which is exactly the scenario the tokenizer comparison harness should exercise.
