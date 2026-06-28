# Travel Desk Dump — airport Wi‑Fi version ✈️📶🧾

Please summarize this like a patient human, not like a sanitizer.
It was copied from a phone, then from hotel email, then from a support chat, then from a boarding queue.
Some lines are duplicated, some are half-translated, some have too many spaces.  That's the point.

## Situation in one breath

Customer bought a last-minute rail+hotel combo while moving between terminals.
Payment likely succeeded, hotel voucher email arrived first, app card appeared later, and the booking title
briefly looked like `CITY / WEST :: fallback`.  Nobody wants poetry; they want clarity without losing the ugly details.

## Mini itinerary pasted from Notes

| step | local time | place | note |
| --- | --- | --- | --- |
| 1 | 05:42 | Sofia Airport | bought combo while boarding alert sounded |
| 2 | 05:47 | Gate A5 | bank push notification ✅ |
| 3 | 05:49 | same gate | app spinner stayed on screen |
| 4 | 05:51 | shuttle bus | hotel voucher email arrived |
| 5 | 06:04 | train app | booking card finally appeared |
| 6 | 06:09 | sleepy panic | title looked half-fallback, half-normal |

## Messages copied from the customer and nearby humans

> EN: "sorry this is all over the place, I'm at the airport and just need to know if I actually booked the thing"

> BG: "Имам банково известие, имам мейл, но приложението още се държи сякаш не ме познава."

> ES: "me salió el correo del hotel antes que la tarjeta del viaje, y pensé que había pagado dos veces"

> PT-BR: "o título ficou estranho por uns segundos, tipo remendo de última hora"

> JA: "メールだけ先に来て、アプリが遅れて追いついた感じです"

> AR: "وصلني الإيميل لكن الشاشة بقيت معلقة، فخفت أن العملية فشلت"

## Loose facts, with exactly the same weird spacing

- booking_total = `€218.40`
- coffee_while_panicking = `€4.20`
- luggage_locker = `€6.00`
- customer_typed = `paid   yes?   app   maybe?   email   yes   confidence   no`
- region_seen = `CITY / WEST :: fallback`
- route_mentioned = `/booking/final?bundle=rail-hotel&tenant=blue-market`
- screenshot_name = `gate-A5 final really final (2).jpg`

## Handoff notes from support desk

1. Do **not** delete accents or odd punctuation.
2. Keep the half-finished sentences; they show order of thought.
3. Preserve emoji trails if they appear next to payment uncertainty.
4. Mention that no duplicate charge was found.
5. Mention that UI delay felt worse because traveler was moving, tired, and offline-on/off.

## Tiny receipts section

| item | total | scribble |
| --- | ---: | --- |
| rail + hotel combo | €218.40 | "booked?? please tell me yes" |
| flat white | €4.20 | triage beverage |
| airport locker | €6.00 | unrelated but sent in same photo |
| station sandwich | €8.70 | annotated with 😵 |

## Pasted blocks that nobody asked for, but we got anyway

```json
{
  "trace": "travel-desk-a5-γ31",
  "tenant": "blue-market",
  "mode": "safe",
  "bundle": "rail-hotel",
  "bank_ping": true,
  "mail_arrived_first": true,
  "booking_card_delay_ms": 103421,
  "title_variants": [
    "City/West",
    "CITY / WEST :: fallback",
    "City-West"
  ],
  "notes": [
    "airport Wi-Fi unstable",
    "customer switching between mail, app, and boarding queue",
    "do not normalize away the messy narrative"
  ]
}
```

```text
mail_subject="Your stay is confirmed — Hotel Verde / 1 night"
push_subject="Bank alert: €218.40 approved"
chat_widget="I have the mail and the bank ping but not the in-app card yet"
path_linux="/srv/apps/travel/current/cards/booking-card.json"
path_windows="C:\travel\captures\airport\gate-A5 final really final (2).jpg"
share_path="\\ops-share\travel\handoff\airport-weekend\mail-first-app-later.txt"
```

```sql
SELECT booking_id, payment_state, mail_state, card_state, locale_hint
FROM travel_cases
WHERE created_at >= '2026-08-02T05:30:00Z'
  AND bundle = 'rail-hotel'
  AND card_state IN ('delayed', 'visible-late', 'recovered')
ORDER BY created_at;
```

## Chat braid from three apps

- `support-widget`: "I can handle delay, I cannot handle uncertainty 😭"
- `mail reply`: "The email says confirmed, the app says wait, and the train says hurry."
- `internal bridge`: "No double charge found. The scary bit is presentation."
- `airport SMS`: "Gate closing soon."
- `customer follow-up`: "now it shows up... why couldn't it do that two minutes earlier"

## Languages, as received

- EN: "messy note because I'm literally walking"
- BG: "Скрийншотът е крив, но текстът е точен."
- ES: "dejé los espacios tal cual porque así venía del chat"
- PT: "não embelezem isso, preciso que o resumo continue honesto"
- JA: "現実の入力は整っていないので、そのまま比較したい"
- AR: "لا تحذفوا الرموز، لأن المستخدم كتبها وهو متوتر"
- FR: "le problème principal n'est pas technique, c'est la confiance"

## Mildly cursed strings worth keeping

1. `family=👨‍👩‍👧‍👦`
2. `accent_demo=e + ́ => é`
3. `airports=SOF → VIE → train? → hotel?`
4. `symbols=[]{}() <> // \\ :: .. ... ~~`
5. `status=paid✅ mail✅ app_card_late🌀 mood😵`
6. `flags=🇧🇬 🇪🇸 🇵🇹 🇯🇵 🇦🇪`
7. `math-ish=delay/attention ≈ panic`

## Travel desk checklist

- [x] verify charge count
- [x] verify voucher email
- [x] verify booking card eventually appeared
- [ ] explain title fallback
- [ ] save five realistic airport-style samples
- [ ] remind everyone that "late but successful" still feels broken

## Rough timeline with more texture

`05:42`  "booking page open, gate call in background, thumbs moving too fast"

`05:47`  bank app ping — `Approved €218.40`

`05:48`  app still shows spinner and sleepy skeleton card

`05:49`  user types: `pls tell me I don't have to do this again`

`05:51`  hotel email lands first, subject line all cheerful, user not cheerful

`05:54`  boarding line advances, customer loses signal for a moment

`05:57`  support writes: `No duplicate charge seen`

`06:04`  app card appears, title style still slightly haunted

`06:09`  customer replies: `okay I think it's real now 😮‍💨`

## Tiny table from hotel front desk chat

| speaker | text |
| --- | --- |
| desk | "We see the reservation." |
| customer | "Great, because the app and I were not aligned." |
| desk | "No worries 🙂" |
| internal note | "worries were, in fact, present" |

## URLs / paths / copied crumbs

- `https://travel.example.test/help/mail-first-card-later`
- `https://status.example.test/incidents/travel-card-delay?ref=airport`
- `/srv/apps/travel/current/cards/booking-card.json`
- `/var/log/travel/edge/airport-a5/render.log`
- `C:\travel\captures\airport\gate-A5 final really final (2).jpg`
- `\\ops-share\travel\handoff\airport-weekend\mail-first-app-later.txt`

## Footer written after coffee and one deep breath

If you need the shortest useful version:

> Payment succeeded, confirmation email beat the in-app card, the UI briefly looked patched together, and the customer's messy airport wording is exactly the evidence we should keep.

status=open-but-stable
confidence=medium+
emoji_tail=✈️📶💳🌀📩🚉☕😮‍💨

