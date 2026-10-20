namespace CalculadoraFilamentoPro.Domain.Users.Entities;

public class User
{
    public User(Guid id, string name, string email, DateTime createdAt, DateTime? lastLogin, bool active)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatedAt = createdAt;
        LastLogin = lastLogin;
        Active = active;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? LastLogin { get; private set; }

    public bool Active { get; private set; }

    public bool SessionActive => LastLogin.HasValue && LastLogin.Value.AddDays(10) > DateTime.Now;

    public void Login()
        => LastLogin = DateTime.Now;
}
