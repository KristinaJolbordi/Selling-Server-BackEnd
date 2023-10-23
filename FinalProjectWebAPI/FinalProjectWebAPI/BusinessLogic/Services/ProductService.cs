using FinalProjectWebAPI.DomainModels.Product;
using FinalProjectWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.BusinessLogic.Services
{
    public class ProductService
    {
        private readonly SellingDbContext _context;

        public ProductService(SellingDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<WarehouseArrangementResult> ArrangeProductInWarehouse(ProductArrangement arrangement)
        {
            var product = await _context.Products.FindAsync(arrangement.ProductId);
            var supplier = await _context.Suppliers.FindAsync(arrangement.SupplierId);

            if (product == null || supplier == null)
                return WarehouseArrangementResult.ProductOrSupplierNotFound;

            var warehouseEntry = new Warehouse
            {
                ProductId = arrangement.ProductId,
                SupplierId = arrangement.SupplierId,
                Quantity = arrangement.Quantity,
                UnitPrice = arrangement.UnitPrice,
                OperationDate = DateTime.Now, 
            };

            _context.Warehouses.Add(warehouseEntry);
            await _context.SaveChangesAsync();

            return WarehouseArrangementResult.Success;
        }
        public async Task<ProductInfo> GetProductInfoById(int id)
        {
            var productInfo = await _context.Products
                .Where(p => p.Id == id)
                .Join(_context.Warehouses,
                      product => product.Id,
                      warehouse => warehouse.ProductId,
                      (product, warehouse) => new ProductInfo
                      {
                          Code = product.Code,
                          Name = product.Name,
                          UnitPrice = warehouse.UnitPrice,
                          UnitOfMeasure = _context.Units
                                           .Where(u => u.Id == warehouse.UnitId)
                                           .Select(u => u.ShortName)
                                           .FirstOrDefault(),
                          Quantity = warehouse.Quantity
                      })
                .FirstOrDefaultAsync();

            return productInfo;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsExpiringIn14Days()
        {
            var today = DateTime.Today;
            var fourteenDaysFromNow = today.AddDays(14);

            return await _context.Warehouses
                .Where(w => w.ExpiryDate >= today && w.ExpiryDate <= fourteenDaysFromNow)
                .Join(
                    _context.Products,
                    warehouse => warehouse.ProductId, 
                    product => product.Id,            
                    (warehouse, product) => new Product
                    {
                        Id = product.Id,
                        Code = product.Code,
                        Name = product.Name,
                    })
                .ToListAsync();
        }
        public async Task ApplyDiscountToProduct(int productId, decimal discountAmount)
        {
            var productInWarehouse = await _context.Warehouses
                .FirstOrDefaultAsync(w => w.ProductId == productId);

            if (productInWarehouse != null)
            {
                productInWarehouse.UnitPrice -= discountAmount;
                _context.Warehouses.Update(productInWarehouse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExpireProducts()
        {
            var today = DateTime.Today;

            var expiredProducts = await _context.Warehouses
                .Where(w => w.ExpiryDate < today)
                .ToListAsync();

            foreach (var warehouseEntry in expiredProducts)
            {
                warehouseEntry.ExpiryDate = today;

                _context.Warehouses.Update(warehouseEntry);
            }
            await _context.SaveChangesAsync();

            return true; 
        }









    }
}
