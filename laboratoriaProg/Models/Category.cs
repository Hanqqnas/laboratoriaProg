using System.ComponentModel.DataAnnotations;

namespace laboratoriaProg.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family, 
    [Display(Name = "Przyjaciele", Order = 3)]
    Friend, 
    [Display(Name = "Kontakt zawodowy", Order = 2)]
    Business,
}