namespace laboratoriaProg.Models.Services;

public class MemoryContactService : IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@wsei.edu.pl",
                Category = Category.Friend,
                BirthDate = new DateOnly(2000, 10, 10),
                PhoneNumber = "+48 222 333 555"
            }
        },
        {
            2, 
            new ContactModel()
            {
                Id = 1,
                FirstName = "Karol",
                LastName = "Kowal",
                Category = Category.Business,
                Email = "adam@wsei.edu.pl",
                BirthDate = new DateOnly(2000, 10, 10),
                PhoneNumber = "+48 222 333 555"
            }
        },
        {
            3, 
            new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Mekowski",
                Email = "adam@wsei.edu.pl",
                Category = Category.Family,
                BirthDate = new DateOnly(2000, 10, 10),
                PhoneNumber = "+48 222 333 555"
            }
        }

    };

    private int _index = 3;

    public void Add(ContactModel model)
    {
        model.Id = ++_index;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}