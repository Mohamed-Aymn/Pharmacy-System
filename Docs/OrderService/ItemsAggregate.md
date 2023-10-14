# Item Aggregate

```json
{
  "id": "0000",
  "name": "item_name",
  "price": {
    "amount": 1000,
    "currency": "USD"
  }
}
```

# Create item request

```json
{
  "id": "0000",
  "name": "item_name",
  "price": {
    "amount": 1000,
    "currency": "USD"
  }
}
```

# Item response

```json
{
  "id": "0000",
  "name": "item_name",
  "price": {
    "amount": 1000,
    "currency": "USD"
  }
}
```

## SQL mapping

- items (
  id PK UUID unique,
  restaurant_id UUID,
  name text,
  price decimal,
  currency string
  )
