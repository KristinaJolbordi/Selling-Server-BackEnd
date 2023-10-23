using Microsoft.AspNetCore.Mvc;

[Route("api/customers/{customerId}/contactpersons")]
[ApiController]
public class ContactPersonController : ControllerBase
{
    private readonly IContactPersonService _contactPersonService;

    public ContactPersonController(IContactPersonService contactPersonService)
    {
        this._contactPersonService = contactPersonService;
    }

    [HttpGet("GetAllContactPersons", Name = "GetAllContactPersons")]
    public ActionResult<IEnumerable<ContactPersonDTO>> GetAllContactPersons(int customerId)
    {
        var contactPersons = _contactPersonService.GetContactPersons(customerId);
        return Ok(contactPersons);
    }

    [HttpGet("GetContactPersonById", Name = "GetContactPersonById")]
    public ActionResult<ContactPersonDTO> GetContactPersonById(int customerId, int contactPersonId)
    {
        var contactPerson = _contactPersonService.GetContactPersonById(contactPersonId);
        return Ok(contactPerson);
    }

    [HttpPost("AddContactPerson", Name = "AddContactPerson")]
    public ActionResult<bool> AddContactPerson(int customerId, [FromBody] ContactPersonDTO contactPerson)
    {
        var result = _contactPersonService.AddContactPerson(customerId, contactPerson);
        return Ok(result);
    }

    [HttpPut("EditContactPerson", Name = "EditContactPerson")]
    public ActionResult<bool> EditContactPerson([FromBody] ContactPersonDTO contactPerson)
    {
        var result = _contactPersonService.EditContactPerson(contactPerson);
        return Ok(result);
    }

    [HttpDelete("DeleteContactPerson", Name = "DeleteContactPerson")]
    public ActionResult<bool> DeleteContactPerson(int contactPersonId)
    {
        var result = _contactPersonService.DeleteContactPerson(contactPersonId);
        return Ok(result);
    }
}
