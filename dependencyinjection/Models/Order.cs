namespace dependencyinjection.Models;

public class Order
{
    public string Code { get; set; }
    public DateTime Date { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal Discount { get; set; }
    public IList<Product> Products { get; set; }
    public decimal SubTotal => Products.Sum(p => p.Price);
    public decimal Total => SubTotal - Discount + DeliveryFee;
    
    public Order(decimal deliveryFee, decimal discount, IList<Product> products)
    {
        Code = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        Date = DateTime.Now;
        DeliveryFee = deliveryFee;
        Discount = discount;
        Products = products;
    }
}