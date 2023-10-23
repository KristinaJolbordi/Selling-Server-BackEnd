using FinalProjectWebAPI.Model;

public class SalesService : ISalesService
{
    private readonly SellingDbContext _dbContext; 

    public SalesService(SellingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Order SellProduct(int customerId, int productId, int quantity)
    {
        if (customerId <= 0 || productId <= 0 || quantity <= 0)
        {
            return null;
        }
        var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return null;
        }
        var order = new Order
        {
            OrderDate = DateTime.Now,
            OrderNumber = GenerateOrderNumber(),
            CustomerId = customerId,
            TotalAmount = 0 
        };
        var orderItem = new OrderItem
        {
            OrderId = order.Id,
            ProductId = productId,
            Quantity = quantity
        };
        var orderItemInfo = _dbContext.OrderItems.SingleOrDefault(oi => oi.OrderId == order.Id && oi.ProductId == productId);
        if (orderItemInfo != null)
        {
            orderItem.UnitPrice = orderItemInfo.UnitPrice;
            orderItem.IsDiscounted = orderItemInfo.IsDiscounted;
            orderItem.DiscountPrice = orderItemInfo.DiscountPrice;
            order.TotalAmount = (int)((orderItem.UnitPrice - (orderItem.DiscountPrice * orderItem.IsDiscounted)) * quantity);
        }
        else
        {
            return null;
        }
        _dbContext.Orders.Add(order);
        _dbContext.OrderItems.Add(orderItem);
        _dbContext.SaveChanges();
        return order;
    }


    public Product GetProductInformation(string productCode)
    {
        var product = _dbContext.Products.SingleOrDefault(p => p.Code == productCode);
        return product;
    }
    public Order GetOrderById(int orderId)
    {
        var order = _dbContext.Orders.SingleOrDefault(o => o.Id == orderId);
        return order;
    }
    private int GenerateOrderNumber()
    {
        long ticks = DateTime.Now.Ticks;
        int orderNumber = (int)(ticks % int.MaxValue);
        return orderNumber;
    }

}
