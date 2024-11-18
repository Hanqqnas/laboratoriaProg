using System.ComponentModel.DataAnnotations;
using laboratoriaProg.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace laboratoriaProg.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz podać imię!")]
    [MaxLength(length: 20, ErrorMessage = "Imię nie może byc dłuższe niż 20 znaków!")]
    [MinLength(length: 2)]
    [Display(Name = "Imię")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Musisz podać nazwisko!")]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko nie może byc dłuższe niż 50 znaków!")]
    [MinLength(length: 2)]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress(ErrorMessage = "Zły email!")]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    
    [Phone]
    [RegularExpression("\\d\\d\\ \\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Wpisz numer według wzoru: xx xxx xxx xxx")]
    public string PhoneNumber { get; set; }
    
    public Category Category { get; set; }
    [Display(Name = "Organizacja")]
    public int OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }
    
    [ValidateNever]
    public List<SelectListItem> Organizations { get; set; } = new List<SelectListItem>();
}