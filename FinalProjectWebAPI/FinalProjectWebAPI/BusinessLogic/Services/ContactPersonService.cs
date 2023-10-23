using FinalProjectWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;

public class ContactPersonService : IContactPersonService
{
    private readonly IContactPersonRepository _contactPersonRepository;

    public ContactPersonService(IContactPersonRepository contactPersonRepository)
    {
        this._contactPersonRepository = contactPersonRepository;
    }

    public bool AddContactPerson(int customerId, ContactPersonDTO contactPerson)
    {
        try
        {
            if (contactPerson == null)
                throw new Exception("Invalid Data");
            contactPerson.CustomerId = customerId;
            _contactPersonRepository.Insert(contactPerson);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool EditContactPerson(ContactPersonDTO contactPerson)
    {
        try
        {
            if (contactPerson == null || !contactPerson.Id.HasValue)
                throw new Exception("Something went wrong! Not found!");
            _contactPersonRepository.Update(contactPerson);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteContactPerson(int contactPersonId)
    {
        try
        {
            var contactPerson = _contactPersonRepository.Get(contactPersonId);
            if (contactPerson == null)
                throw new Exception("Something went wrong! Not found!");

            _contactPersonRepository.Delete(contactPerson);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public ContactPersonDTO GetContactPersonById(int contactPersonId)
    {
        try
        {
            var contactPerson = _contactPersonRepository.Get(contactPersonId);
            return contactPerson;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<ContactPersonDTO> GetContactPersonsByCustomerId(int customerId)
    {
        try
        {
            var contactPersons = _contactPersonRepository.GetContactPersonsByCustomerId(customerId);
            return contactPersons;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<ContactPersonDTO> GetContactPersons(int customerId)
    {
        try
        {
            var contactPersons = _contactPersonRepository.GetContactPersonsByCustomerId(customerId);
            return contactPersons;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
