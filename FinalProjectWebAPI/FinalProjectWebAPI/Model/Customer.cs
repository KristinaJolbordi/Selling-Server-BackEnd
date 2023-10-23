using FinalProjectWebAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWebAPI.Model;

public partial class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; } = null!;
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; } = null!;
    [Required]
    public int GenderId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 4)]
    public string PersonalNumber { get; set; } = null!;
    [Required(ErrorMessage = "Date of birth is required.")]
    [CustomerAgeValidation(18)]
    public DateTime BirthDate { get; set; }
    [Required]
    public int CityId { get; set; }
    [Required]
    public int CountryId { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;
    [Required]
    public string Adress { get; set; } = null!;
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string Pn { get; set; } = null!;
}
