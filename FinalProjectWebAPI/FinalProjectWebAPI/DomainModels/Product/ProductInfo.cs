namespace FinalProjectWebAPI.DomainModels.Product
{
    public class ProductInfo 
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
        public int Quantity { get; set; }
    }

}
