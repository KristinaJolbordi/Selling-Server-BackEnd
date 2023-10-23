namespace FinalProjectWebAPI.DomainModels.Product
{
    public enum WarehouseArrangementResult
    {
        Success,
        ProductOrSupplierNotFound,



    }

    public class ProductArrangement
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }



}
