using System;
using System.Linq;
using FinalProjectWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly SellingDbContext _dbContext;
        public ReportsController(SellingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("contact-information")]
        public IQueryable<object> GetContactInformation()
        {
            var query = from customer in _dbContext.Customers
                        join city in _dbContext.Cities on customer.CityId equals city.Id
                        join country in _dbContext.Countries on customer.CountryId equals country.Id
                        select new
                        {
                            FullName = customer.FirstName + " " + customer.LastName,
                            PhoneNumber = _dbContext.CustomersPhoneNumbers
                                .Where(cp => cp.CustomerId == customer.Id && cp.IsMain == "Select Main Only")
                                .Select(cp => cp.PhoneNumber)
                                .FirstOrDefault(),
                            PhoneType = _dbContext.PhoneTypes
                                .Where(pt => pt.Id == _dbContext.CustomersPhoneNumbers
                                    .Where(cp => cp.CustomerId == customer.Id && cp.IsMain == "Select Main Only")
                                    .Select(cp => cp.PhoneTypeId)
                                    .FirstOrDefault())
                                .Select(pt => pt.Name)
                                .FirstOrDefault(),
                            customer.Email,
                            CountryName = country.Name,
                            CityName = city.Name,
                            customer.Adress
                        };
            return query;
        }
        [HttpGet("sorted-individuals-with-orders")]
        public IQueryable<object> GetSortedIndividualsWithOrders()
        {
            var query = from customer in _dbContext.Customers
                        join order in _dbContext.Orders on customer.Id equals order.CustomerId
                        where order.TotalAmount > 2
                        orderby customer.BirthDate descending
                        select new
                        {
                            FullName = customer.FirstName + " " + customer.LastName,
                            customer.BirthDate
                        };

            return query;
        }
        [HttpGet("city-order-statistics")]
        public IQueryable<object> GetCityOrderStatistics()
        {
            var query = from customer in _dbContext.Customers
                        join order in _dbContext.Orders on customer.Id equals order.CustomerId
                        join city in _dbContext.Cities on customer.CityId equals city.Id
                        group order.TotalAmount by city.Name into cityGroup
                        select new
                        {
                            City = cityGroup.Key,
                            TotalOrderAmount = cityGroup.Sum()
                        };

            return query;
        }
        [HttpGet("top-3-sports-equipment")]
        public IQueryable<object> GetTop3SportsEquipment()
        {
            var query = from product in _dbContext.Products
                        join orderItem in _dbContext.OrderItems on product.Id equals orderItem.ProductId
                        where product.CategoryId == 3 // Assuming 3 represents the SportsEquipment category
                        group orderItem.Quantity by product.Name into productGroup
                        orderby productGroup.Sum() descending
                        select new
                        {
                            ProductName = productGroup.Key,
                            TotalSales = productGroup.Sum()
                        };

            return query.Take(3);
        }
        [HttpGet("most-expensive-books")]
        public object GetMostExpensiveBooks()
        {
            var query = from orderItem in _dbContext.OrderItems
                        join product in _dbContext.Products on orderItem.ProductId equals product.Id
                        where product.CategoryId == 2
                        orderby orderItem.UnitPrice descending
                        select new
                        {
                            product.Name,
                            product.CategoryId,
                            UnitPrice = orderItem.UnitPrice
                        };

            return query.FirstOrDefault();
        }
        [HttpGet("toys-for-children-under-3")]
        public IQueryable<object> GetToysForChildrenUnder3()
        {
            var query = from product in _dbContext.Products
                        where product.CategoryId == 1 // Assuming 1 represents the Toys category
                            && product.AgeRecommendation < 3
                        select new
                        {
                            product.Name,
                            product.AgeRecommendation
                        };

            return query;
        }
        [HttpGet("most-passive-supplier")]
        public IActionResult GetMostPassiveSupplier()

        {
            var query = from supplier in _dbContext.Suppliers
                        join warehouse in _dbContext.Warehouses on supplier.Id equals warehouse.SupplierId into supplierWarehouse
                        let totalQuantity = supplierWarehouse.Sum(w => w.Quantity)
                        orderby totalQuantity
                        select new SupplierInfo
                        {
                            Supplier = supplier,
                            TotalQuantity = totalQuantity
                        };
            var result = query.FirstOrDefault();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();


        }
        [HttpGet("top-ten-products-for-retirement-age-users")]
        public IQueryable<object> GetTopTenProductsForRetirementAgeUsers()
        {
            var retirementAge = DateTime.Now.AddYears(-65); // Assuming retirement age is 65
            var query = from customer in _dbContext.Customers
                        join order in _dbContext.Orders on customer.Id equals order.CustomerId
                        where (customer.GenderId == 1 && customer.BirthDate <= retirementAge.AddYears(-5)) ||
                              (customer.GenderId == 2 && customer.BirthDate <= retirementAge)
                        join orderItem in _dbContext.OrderItems on order.Id equals orderItem.OrderId
                        group orderItem.Quantity by orderItem.ProductId into productGroup
                        orderby productGroup.Sum() descending
                        select new
                        {
                            ProductId = productGroup.Key,
                            TotalQuantity = productGroup.Sum()
                        };

            return query.Take(10);
        }

    }
}
