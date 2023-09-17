namespace Domain.Core.Entities;

public class User: Entity<User>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool Active { get; private set; }

    public User(string name, string email, string password, bool active)
    {
        Name = name;
        Email = email;
        Password = password;
        Active = active;
    }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}