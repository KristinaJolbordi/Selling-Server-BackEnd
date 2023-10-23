using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWebAPI.DomainModels.Customer
{
    public class CustomerDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int GenderId { get; set; }
        public string PersonalNumber { get; set; } = null!;
        public string PhoneType { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Pn { get; set; } = null!;
    }
}
