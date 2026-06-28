# Weekend Escalation Digest — copied from phone, laptop, and two sticky notes

Need this condensed for Monday 08:30, but please don't "clean it up" too much.
The mess is part of the point: real users paste receipts, chats, paths, screenshots-as-text,
and whatever their keyboard coughs up at 07:12 when the queue is red.  Keep accents, odd spacing,
emoji clusters, and lines that look half-finished.

---

## Fast summary typed in the tram 🚋☕

- Main complaint: confirmation screen loaded, then the main CTA stayed gray for 19-40 seconds.
- Secondary complaint: dashboard title flickered between `North/West`, `NØRTH\WEST`, and `NORTH :: WEST`.
- Mobile users pasted more broken-looking but more realistic text than desktop users.
- We saw mixed languages in one thread: English + Български + Español + Français + 日本語.
- Nobody asked for a perfect essay. They asked for: "tell me what happened, what's noisy, what's dangerous."

## Tiny urgency meter

| bucket | count | note |
| --- | ---: | --- |
| "app frozen??" | 11 | not fully frozen, more like partial render |
| "payment done but spinner stayed" | 7 | receipts attached, usually blurry |
| "wrong region label" | 5 | mostly `North/West` variants |
| "support chat pasted everything" | 14 | screenshots described in prose, lots of emoji |
| "actual outage" | 1 | short spike, already recovered |

## Timeline, reconstructed from many tabs

| time | source | note |
| --- | --- | --- |
| 06:58 | ops room | first "is anyone awake?" ping, no details |
| 07:03 | customer mail | "screen okay, button not okay, money maybe okay??" |
| 07:06 | Sofia chat | `Пази raw текста, даже да изглежда грозно.` |
| 07:08 | Madrid chat | `la tabla volvió, pero el botón "Confirmar" siguió gris 😑` |
| 07:12 | support inbox | screenshot retyped as prose with arrows, stars, and three crying emojis |
| 07:18 | Paris note | `ne normalisez pas les accents, sinon on perd la moitié du signal` |
| 07:24 | incident bridge | someone pasted both JSON and a grocery receipt into the same thread |
| 07:31 | mobile feedback form | extra spaces, emoji, and mixed newline styles everywhere |
| 07:46 | quick replay | issue faded, but title string still looked cursed |

## Quotes copied exactly

> Marta (ES): "se cobró, creo, pero la pantalla quedó pensando   y yo también"

> Ivo (BG): "Не махайте странните символи. Ако потребителят ги е пратил, значи са важни."

> Luc (FR): "le tableau a respiré, puis il a rechuté... pas cassé, juste très fatigué"

> Mina (EN): "if the parser smiles at neat text and panics at reality, that's our bug, not theirs"

> Yuki (JA): "半角と全角が混ざると、短い文でも雰囲気が一気に現実寄りになる"

## Chat scraps from three places at once

- `07:11` support-app:
  `hey sorry for the dump but user sent: "Paid €18.05 / spinner / retry / no email / then email / then no ticket in app / then yes ticket ???"`
- `07:13` field-sales:
  `cliente de Porto Alegre escreveu: "foi, não foi, voltou, travou, abriu de novo" 😵‍💫`
- `07:16` internal note:
  `route=/checkout/final?region=eu-west::17&mode=retry`
- `07:17` side comment:
  `why is the title "NØRTH\WEST" again   who touched the fallback label`
- `07:19` copied from phone:
  `👩🏽‍💻 → paid → spinner → screenshot → coffee → "pls just explain" ☕➡️💳➡️🌀➡️📷`

## Pasted support digest (messy on purpose)

```text
case_id=CS-88419
tenant=blue-market
customer="A. Petrova"
locale_guess=bg-BG + en-GB + "whatever the airport Wi-Fi did"
summary="payment appears accepted; UI lagged; receipt arrived first; ticket card arrived later"
device="iPhone 15 / low battery / roaming"
path_mentioned="/srv/apps/front/current/labels/regions.json"
windows_path="C:\ops\captures\weekend\label-flip\screen 4 final FINAL.png"
odd_string="NØRTH\WEST  ::  confirm   ::   retry_retry"
emoji_trail="😵 📩 ☕ ✅ ❓"
```

```json
{
  "trace": "weekend-7f9a-β17",
  "mode": "safe",
  "region": "eu-west/blue::17",
  "flags": ["retry", "shadow", "label-fallback", "preserve-spacing"],
  "observed_titles": ["North/West", "NØRTH\\WEST", "NORTH :: WEST"],
  "receipts": [
    {"total": "€18.05", "status": "captured"},
    {"total": "€4.20", "status": "coffee, unrelated but attached anyway"}
  ],
  "notes": [
    "button stayed disabled after success payload",
    "users often paste narrative + logs + refund fear in one paragraph",
    "keep UTF-8, quotes, slashes, and weird punctuation"
  ]
}
```

```sql
SELECT case_id, locale, payment_state, ui_state, created_at
FROM escalations
WHERE created_at >= '2026-06-14T06:30:00Z'
  AND region IN ('eu-west', 'eu-west::17', 'north/west')
  AND ui_state IN ('spinner', 'disabled-button', 'recovered-ish')
ORDER BY created_at ASC;
```

## Receipt corner, because apparently everything ends up here

- receipt A: `€18.05` — "ticket + seat + accidental insurance maybe"
- receipt B: `€4.20` — flat white, annotated with `needed to survive triage`
- receipt C: `17,90 €` — kiosk sandwich + water + "do not expense???"
- note on the back: `email came at 07:14, app card came at 07:26, panic peaked at 07:15`

## Raw strings worth preserving for tokenizer tests

1. `family=👨‍👩‍👧‍👦`
2. `accent_demo=e + ́ => é ; composed => é`
3. `currencies=€ £ ¥ ₹ R$ CHF`
4. `symbols=[]{}() <> // \\ :: == != <= >=`
5. `operators=&& || ?? ?: => -> ← → ↯`
6. `noise=§ ¶ ※ • ◦ ‼ ‽`
7. `flags=🇧🇬 🇪🇸 🇫🇷 🇯🇵 🇧🇷`
8. `mood="messy but real"`

## URLs / paths / things people pasted without context

- `https://status.example.test/incidents/blue-market?ref=weekend&lang=bg`
- `https://help.example.test/checkout/button-disabled#north-west-label`
- `/srv/apps/front/current/labels/regions.json`
- `/var/log/edge/blue-17/render/2026-06-14.log`
- `C:\Users\ops\Desktop\weekend\final\screen-07 "real final".png`
- `\\bridge-share\support\handoff\weekend\label_flip\customer_quotes.txt`

## Handwritten table, retyped badly

| who | what they meant | what they actually sent |
| --- | --- | --- |
| support | quick summary | 9 screenshots + 3 copied captions + 1 receipt |
| customer | "button broken" | payment fear + travel panic + app details + emoji storm |
| ops | reproduce issue | path strings, trace IDs, one sarcastic sentence |
| PM | risk level | "is this scary or just ugly?" |

## Fragments from multilingual thread

- EN: "I know this looks chaotic, but it's exactly how the customer sent it."
- BG: "Ако опростим текста прекалено, после няма да видим къде се чупи."
- ES: "dejen los espacios raros, la usuaria copió desde WhatsApp y desde el correo"
- FR: "les doubles guillemets et les slashs comptent aussi"
- JA: "絵文字の並びも意味を持っていることがある"
- PT-BR: "o texto ficou feio, sim, mas ficou honesto"

## Mini checklist left by the monitor

- [x] confirm payment did not duplicate
- [x] verify mail send time
- [x] replay label fallback
- [ ] explain why disabled state lingered
- [ ] keep five weird examples for regression pack

## Footer typed in the elevator, nearly out of battery 🔋

If you need one sentence:

> The incident was short, the fear was real, the pasted input was gloriously messy, and any test set that only uses clean English strings will miss the exact shape of this failure.

last_seen=07:46
coffee_level=high
confidence=medium+
emoji_tail=☕🧾📩🌀✅😮‍💨

