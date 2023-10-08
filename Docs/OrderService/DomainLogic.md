# Domain Logic Diagram

<img src="DomainLogicDiagram.png"
     alt="DomainLogicDiagram"
     />

# Aggregates JSON samples

## Order Aggregate

```json
{
  "id": "000000000-0000000-00000000000-0000000000",
  "customerId": "000000",
  "restaurantId": "000000",
  "deliveryAddress": {
    "id": "0000",
    "strees": "street",
    "postal_code": 216537,
    "city": "alexandria"
  },
  "price": {
    "amount": 1000,
    "currency": "USD"
  },
  "items": ["0000", "0000"],
  "trackingId": "0000",
  "orderStatus": "deliverd",
  "failureMessages": ["message one", "message two"]
}
```

SQL tables

- orders (id, customer_id, restaurant_id, delivery_address, price, currency, tracking_id, order_status, failure_messages, items)

## Restaurant Aggregate

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

SQL tables

- restaurant (id, is_active)
- items (id, restaurant_id, name, price, currency)

## Customer Aggregate

```json
{
  "customerId": "0000",
  "addresses": ["0000", "0000", "0000"]
}
```

SQL Tables

- customer (id, addresses)

## Address Aggregate

```json
{
  "id": "0000",
  "customer_id": "0000",
  "strees": "street",
  "postal_code": 216537,
  "city": "alexandria"
}
```
