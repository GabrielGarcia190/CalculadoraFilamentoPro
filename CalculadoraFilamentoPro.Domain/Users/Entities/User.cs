using CalculadoraFilamentoPro.Domain.Filaments.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraFilamentoPro.Domain.Users.Entities;

public class User
{
    private User()
    {
    }

    public User(string userName, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("O nome de usuário é obrigatório.", nameof(userName));

        var normalizedUserName = userName.Trim();

        if (normalizedUserName.Length is < 3 or > 50)
            throw new ArgumentException("O nome de usuário deve possuir entre 3 e 50 caracteres.", nameof(userName));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("O hash da senha é obrigatório.", nameof(passwordHash));

        UserName = normalizedUserName.ToLowerInvariant();
        PasswordHash = passwordHash;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private set; }

    [Required]
    [MaxLength(50)]
    public string UserName { get; private set; } = string.Empty;

    [Required]
    [MaxLength(256)]
    public string PasswordHash { get; private set; } = string.Empty;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; private set; }

    public DateTime? LastLogin { get; private set; }

    public bool SessionActive => LastLogin.HasValue && LastLogin.Value.AddDays(10) > DateTime.UtcNow;

    public void Login()
        => LastLogin = DateTime.UtcNow;

    public ICollection<Filament> Filaments { get; private set; } = new List<Filament>();
}
