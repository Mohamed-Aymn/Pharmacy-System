# Restaurant Aggregate

```json
{
  "id": "0000",
  "items": ["0000"],
  "active": true
}
```

# Create restaurant request

```json
{
  "id": "0000",
  "active": true
}
```

# Restaurant response

Note: This is a the rich json response structure instead of providing raw IDs.

```json
{
  "id": "0000",
  "items": [
    {
      "id": "0000",
      "name": "item_name",
      "price": {
        "amount": 1000,
        "currency": "USD"
      }
    }
  ],
  "active": true
}
```

## SQL mapping

- restaurant (
  id PK UUID unique,
  is_active bool
  )
