namespace laboratoriaProg.Models;

public class Birth
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Name) && BirthDate < DateTime.Now;
    }

    public int CalculateAge()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (BirthDate > DateTime.Now.AddYears(-age)) age--;
        return age;
    }
}