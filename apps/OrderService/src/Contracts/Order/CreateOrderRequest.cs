namespace OrderService.Contracts;

public class CreateOrderRequest
{
    public string Id { get; set; }
    public string Restaurant { get; set; }
    public string DeliveryAddress { get; set; }
    public double Price { get; set; }
    public CreateOrderRequest(string id, string restaurant, string deliveryAddress, double price)
    {
        Id = id;
        Restaurant = restaurant;
        DeliveryAddress = deliveryAddress;
        Price = price;
    }
}