## Integrity Snapshot

| metric | value | delta | note |
| --- | ---: | ---: | --- |
| requests_total | 1,204,991 | +0.8% | stable overall |
| parser_retries | 7,441 | +18.2% | noisy after 03:00 |
| failed_exports | 19 | +11 | tied to `exp.3` |
| cache_hit_ratio | 0.973 | -0.004 | acceptable |
| unicode_edge_cases | 42 | +27 | emoji + decomposed chars |
| mixed_newline_samples | 31 | +14 | copied from terminal + chat |
| separator_collisions | 17 | +9 | `::`, `//`, `_` repeated |

### Highlights

- Region `eu-west/blue::17` generated the largest retry spike.
- Worst offending sample contained `¯\_(ツ)_/¯`, `👨‍👩‍👧‍👦`, `e\u0301`, `Δelta`, and `NØRTH\\WEST`.
- Median latency stayed flat, but p99 wandered from **241ms** to **388ms**.
- The shortest prompts remained the least representative of production traffic.

### Locale notes

| locale | sample | observation |
| --- | --- | --- |
| bg-BG | `Пусни build-а след обяд.` | Cyrillic + Latin mixed naturally |
| ja-JP | `ログを三回チェックする` | compact and dense |
| ar-SA | `خلّي الرموز كما هي` | right-to-left text kept intact |
| mix | `route=/x/μ?flag=ß&ok=true` | separators dominate quickly |
| emoji | `👨‍👩‍👧‍👦 ☕🧾🧪➡️✅` | ZWJ clusters skew token estimates |

### Tiny risk register

1. Very short demos make separator-heavy inputs look cheaper than they are.
2. Confusables like `A Α А` and combined forms like `é` are easy to miss in visual review.
3. Copy-pasted paths, Markdown tables, YAML, and inline JSON create realistic but tokenizer-hostile blends.

### Recommendation

Replay the five weirdest payloads before merging any tokenizer heuristic changes, especially those involving normalization, path splitting, or emoji handling.

### Sample payload gallery

| sample | shape | why it matters |
| --- | --- | --- |
| `hey — can you sanity-check this weird line?` | short natural text | baseline small prompt |
| `route=/api/v1/ping?mode=tiny&lang=bg-BG` | terse path-heavy text | separators dominate fast |
| `Пусни build-а след обяд.` | mixed Cyrillic + Latin | common real-world blend |
| `ログを三回チェックする` | compact Japanese | dense token packing |
| `👨‍👩‍👧‍👦 :: e\u0301 :: Δelta :: ¯\_(ツ)_/¯` | emoji + accents + symbols | worst-case tiny chaos |

### Notes from the scrape

- A single dashboard paste often contains a title, a file path, a mini table, and one emotional aside like "why is this like this".
- The most realistic samples were not nonsense; they looked like exhausted humans copying from three tools at once.
- Path separators, currency signs, Markdown fences, and JSON quoting amplify token count variance more than plain prose.
- A short clean sentence is useful, but it should live next to increasingly messy samples, not replace them.

### Confusables and normalization watchlist

| family | example | risk |
| --- | --- | --- |
| composed vs decomposed | `é` vs `é` | visually similar, bytewise different |
| Latin vs Greek vs Cyrillic | `A Α А` | easy to miss in logs |
| slash variants | `/`, `\\`, `//`, `::` | chunking and parsing drift |
| emoji clusters | `👩🏽‍💻`, `👨‍👩‍👧‍👦` | ZWJ and modifiers |
| width/style | half-width vs full-width | hidden token jumps |

### Extra recommendation

Keep one or two tiny clean files for sanity checks, but bias the rest of the demo corpus toward messy, believable inputs with multilingual text, symbols, code fragments, and varied formatting.
