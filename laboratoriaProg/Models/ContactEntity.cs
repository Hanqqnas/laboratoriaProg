using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using laboratoriaProg.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace laboratoriaProg.Models;

[Table(name: "Contact")]
public class ContactEntity
{
    public int Id { get; set; }
    [Required]
    [MaxLength(length: 20)]
    [MinLength(length: 2)]        
    public string FirstName { get; set; }
    
    [MaxLength(length: 20)]    
    [MinLength(length: 2)]    
    public string LastName { get; set; }
    
    [MaxLength(length: 20)]
    [MinLength(length: 2)]
    public string Email { get; set; }
    
    [Phone(ErrorMessage = "Zły numer telefonu!!")]
    [Display(Name = "Numer telefonu")]
    [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "FORMAT: XXX XXX XXX!!")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia")]
    public DateOnly BirthDate { get; set; }
    
    public Category Category { get; set; }
    
    public DateTime Created { get; set; }
    
    public int OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }
}