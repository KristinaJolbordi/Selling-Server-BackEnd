namespace FinalProjectWebAPI.DomainModels.Product
{
    public class WarehouseDTO
    {
        // Other properties...

        public int ProductId { get; set; }

        // Define the navigation property to Products
        public ProductInfo Product { get; set; }
    }

}
