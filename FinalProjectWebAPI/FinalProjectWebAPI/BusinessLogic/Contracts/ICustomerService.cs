using FinalProjectWebAPI.DomainModels.Customer;

namespace FinalProjectWebAPI.BusinessLogic.Contracts
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetCustomers();
        CustomerDTO GetCustomerById(int customerId);
        bool RegisterCustomer(CustomerDTO customer);
        bool EditCustomer(CustomerDTO customer);
        bool DeleteCustomer(int customerId);

    }
}
