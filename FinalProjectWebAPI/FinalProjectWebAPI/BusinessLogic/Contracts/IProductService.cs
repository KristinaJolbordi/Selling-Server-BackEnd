
using FinalProjectWebAPI.DomainModels.Product;
using FinalProjectWebAPI.Model;

public interface IProductService
{
    Task<Product> AddProduct(Product product);
    Task<bool> ArrangeProductInWarehouse(ProductArrangement arrangement);
    Task<Product> UpdateProduct(Product product);
    Task<bool> DeleteProduct(int id);
    Task<ProductInfo> GetProductInfoById(int id);
    Task<List<Product>> GetAllProducts();
    Task<IEnumerable<Product>> GetProductsExpiringIn14Days();
    Task ApplyDiscountToProduct(int productId, decimal discountAmount);
    Task<bool> ExpireProducts();
}
