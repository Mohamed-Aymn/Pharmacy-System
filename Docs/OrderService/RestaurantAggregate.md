# Restaurant Aggregate

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

# Create restaurant request

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

- restaurant (id, is_active)
- items (id, restaurant_id, name, price, currency)
