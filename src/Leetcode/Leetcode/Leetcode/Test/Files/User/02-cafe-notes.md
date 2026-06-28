# Cafe Notes, Round 2

Need a fast human summary of the following scraps before lunch. Keep the accents, keep the weird punctuation, and **do not** normalize the emoji.

## Receipts and tiny context

- flat white: €4.20
- sesame pastry: €3.80
- emergency sparkling water: €1.10
- second receipt from later: €18.05 for "team fuel / maybe excessive"
- cash drawer note: `coins low, card reader flaky after 14:00`

## Messages copied from phones and sticky notes

- Mina: "ship the patch, but leave `auth_v2` asleep for one more day"
- Pavel: "Пусни build-а след обяд, не преди това."
- Yuki: "ログを三回チェックする。雑でもいいから記録して。"
- Samir: "خلي النسخة التجريبية شغالة، لكن بدون ضجيج."
- tiny emoji trail: ☕🧾🧪➡️✅➡️😮‍💨

## Table fragment found next to the register

| key | value |
| --- | --- |
| branch | `feature/tokenizer-sweep` |
| patch_level | `2026.05.14-exp.2` |
| odd_string | `NØRTH\\WEST::β` |
| reminder | `compare short prompts vs mixed-script prompts` |

## SQL-ish block that somebody insisted mattered

```sql
SELECT id, status, locale, retry_count
FROM jobs
WHERE status IN ('queued', 'stuck', 'half-awake')
  AND created_at > '2026-05-01T00:00:00Z'
  AND locale IN ('en', 'bg', 'ja', 'mix');
```

Final thought scribbled at the bottom:

> if the tokenizer smiles at `¯\_(ツ)_/¯` but chokes on `👨‍👩‍👧‍👦`, maybe the problem is not the user.

