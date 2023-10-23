using FinalProjectWebAPI.Model;
using FinalProjectWebAPI.Repositories.Interfaces;

namespace FinalProjectWebAPI.Repositories.Repositories
{
    public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SellingDbContext context):base(context)
        {
            
        }
    }
}
