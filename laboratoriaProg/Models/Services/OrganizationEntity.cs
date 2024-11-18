namespace laboratoriaProg.Models.Services;

public class OrganizationEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NIP { get; set; }
    public string REGION { get; set; }
    public Address? Address { get; set; } //klasa osadzona
    public ISet<ContactEntity> Contacts { get; set; } //pole nawigacyjne
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}