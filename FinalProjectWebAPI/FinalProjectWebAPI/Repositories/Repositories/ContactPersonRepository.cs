using FinalProjectWebAPI.Model;
using System.Collections.Generic;
using System.Linq;

public class ContactPersonRepository : BaseRepository<ContactPersonDTO>, IContactPersonRepository
{
    public ContactPersonRepository(SellingDbContext context) : base(context)
    {
    }
    public List<ContactPersonDTO> GetContactPersonsByCustomerId(int customerId)
    {
        return entities.Where(cp => cp.CustomerId == customerId).ToList();
    }
}
