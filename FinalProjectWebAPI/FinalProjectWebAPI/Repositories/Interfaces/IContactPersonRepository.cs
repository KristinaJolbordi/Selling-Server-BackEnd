using FinalProjectWebAPI.Repositories.Interfaces;
using System.Collections.Generic;

public interface IContactPersonRepository : IBaseRepository<ContactPersonDTO>
{
    List<ContactPersonDTO> GetContactPersonsByCustomerId(int customerId);
}
