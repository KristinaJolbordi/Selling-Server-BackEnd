using FinalProjectWebAPI.Model;

public interface ISalesService
{
    Order SellProduct(int customerId, int productId, int quantity);
    Product GetProductInformation(string productCode);
    Order GetOrderById(int orderId);
}
