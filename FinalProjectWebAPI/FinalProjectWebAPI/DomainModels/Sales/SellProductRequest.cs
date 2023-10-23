namespace FinalProjectWebAPI.DomainModels.Sales
{
    public class SellProductRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
