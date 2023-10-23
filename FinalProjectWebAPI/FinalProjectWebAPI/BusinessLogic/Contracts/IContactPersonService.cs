using System.Collections.Generic;

public interface IContactPersonService
{
    List<ContactPersonDTO> GetContactPersons(int customerId);
    ContactPersonDTO GetContactPersonById(int contactPersonId);
    List<ContactPersonDTO> GetContactPersonsByCustomerId(int customerId);
    bool AddContactPerson(int customerId, ContactPersonDTO contactPerson);
    bool EditContactPerson(ContactPersonDTO contactPerson);
    bool DeleteContactPerson(int contactPersonId);
}
