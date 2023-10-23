using FinalProjectWebAPI.BusinessLogic.Contracts;
using FinalProjectWebAPI.DomainModels.Customer;
using FinalProjectWebAPI.Model;
using FinalProjectWebAPI.Repositories.Interfaces;

namespace FinalProjectWebAPI.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public bool RegisterCustomer(CustomerDTO customer)
        {
            try
            {
                if (customer == null)
                    throw new Exception("Invalid Data");

                Customer c = new Customer();

                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.GenderId = customer.GenderId;
                c.Email = customer.Email;
                c.BirthDate = customer.BirthDate;
                c.Adress = customer.Adress;
                c.CityId = customer.CityId;
                c.CountryId = customer.CountryId;
                c.Pn = customer.Pn;

                _customerRepository.Insert(c);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditCustomer(CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                    throw new Exception("Something went wrong! Not found!");

                var c = _customerRepository.Get(customer.Id.Value);
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.Email = customer.Email;
                _customerRepository.Update(c);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = _customerRepository.Get(customerId);
                if (customer == null)
                    throw new Exception("Something went wrong! Not found!");
                _customerRepository.Delete(customer);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public CustomerDTO GetCustomerById(int customerId)
        {
            try
            {
                var c = _customerRepository.Get(customerId);
                CustomerDTO result = new CustomerDTO
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    GenderId = c.GenderId,
                    Email = c.Email,
                    BirthDate = c.BirthDate,                   
                    CityId = c.CityId,
                    CountryId = c.CountryId,
                    Adress = c.Adress,
                    Pn = c.Pn,
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<CustomerDTO> GetCustomers()
        {
            try
            {
                var customers = _customerRepository.GetAll();
                List<CustomerDTO> result = customers.Select(c => new CustomerDTO
                {
                    Id = c.Id,
                    Pn = c.Pn,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    GenderId = c.GenderId,
                    Email = c.Email,
                    BirthDate = c.BirthDate,
                    Adress = c.Adress,
                    CityId = c.CityId,
                    CountryId = c.CountryId,
                }
                ).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
