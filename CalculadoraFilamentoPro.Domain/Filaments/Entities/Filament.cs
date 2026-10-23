using CalculadoraFilamentoPro.Domain.Filaments.Enums;
using CalculadoraFilamentoPro.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraFilamentoPro.Domain.Filaments.Entities;

public class Filament
{
    private Filament() { }

    private Filament(string name,
                     string color,
                     EFilamentType type,
                     decimal costPrice,
                     string brand,
                     DateTime purchaseDate,
                     decimal originalWeight,
                     Guid userId)
    {
        Name = name.Trim();
        Color = color.Trim();
        Type = type;
        CostPrice = costPrice;
        Brand = brand.Trim();
        PurchaseDate = purchaseDate;
        OriginalWeight = originalWeight;
        UsedWeight = 0;
        Status = EFilamentStatus.Active;
        CreatedAt = DateTime.UtcNow;
        UserId = userId;

        Validate();
    }

    public static Filament Create(Guid userId,
                                  string name,
                                  string color,
                                  EFilamentType type,
                                  decimal costPrice,
                                  string brand,
                                  DateTime purchaseDate,
                                  decimal originalWeight)
    {
        return new Filament(name, color, type, costPrice, brand, purchaseDate, originalWeight, userId);
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private set; }

    public DateTime CreatedAt { get; private set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; private set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Color { get; private set; } = string.Empty;

    [Required]
    public EFilamentType Type { get; private set; }

    [Precision(18, 2)]
    public decimal CostPrice { get; private set; }

    [Required]
    [MaxLength(80)]
    public string Brand { get; private set; } = string.Empty;

    [Required]
    public DateTime PurchaseDate { get; private set; }

    [Precision(18, 2)]
    public decimal OriginalWeight { get; private set; }

    [Precision(18, 2)]
    public decimal UsedWeight { get; private set; }

    [Required]
    public EFilamentStatus Status { get; private set; }

    [Required]
    public Guid UserId { get; private set; }

    public User User { get; private set; } = null!;

    [NotMapped]
    public decimal RemainingWeight => OriginalWeight - UsedWeight;

    public void Consume(decimal weight)
    {
        if (weight <= 0)
            throw new ArgumentException("O peso consumido deve ser maior que zero.");

        if (UsedWeight + weight > OriginalWeight)
            throw new InvalidOperationException("O peso consumido não pode ser maior que o peso disponível.");

        UsedWeight += weight;

        if (RemainingWeight == 0)
            Status = EFilamentStatus.Finished;
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("O preço deve ser maior que zero.");

        CostPrice = newPrice;
    }

    public void ChangeStatus(EFilamentStatus status)
        => Status = status;

    public void UpdateInformation(string name,
                                  string color,
                                  EFilamentType type,
                                  decimal costPrice,
                                  string brand,
                                  DateTime purchaseDate,
                                  decimal originalWeight)
    {
        Name = name.Trim();
        Color = color.Trim();
        Type = type;
        CostPrice = costPrice;
        Brand = brand.Trim();
        PurchaseDate = purchaseDate;
        OriginalWeight = originalWeight;

        Validate();
    }

    private void Validate()
    {
        if (UserId == Guid.Empty)
            throw new ArgumentException("Usuário inválido.");

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("O nome do filamento é obrigatório.");

        if (Name.Length > 50)
            throw new ArgumentException("O nome do filamento deve possuir no máximo 50 caracteres.");

        if (string.IsNullOrWhiteSpace(Color))
            throw new ArgumentException("A cor do filamento é obrigatória.");

        if (Color.Length > 50)
            throw new ArgumentException("A cor do filamento deve possuir no máximo 50 caracteres.");

        if (string.IsNullOrWhiteSpace(Brand))
            throw new ArgumentException("A marca é obrigatória.");

        if (Brand.Length > 80)
            throw new ArgumentException("A marca deve possuir no máximo 80 caracteres.");

        if (CostPrice <= 0)
            throw new ArgumentException("O preço deve ser maior que zero.");

        if (OriginalWeight <= 0)
            throw new ArgumentException("O peso original deve ser maior que zero.");

        if (UsedWeight < 0)
            throw new ArgumentException("O peso utilizado não pode ser negativo.");

        if (UsedWeight > OriginalWeight)
            throw new ArgumentException("O peso utilizado não pode ser maior que o peso original.");

        if (PurchaseDate > DateTime.Today)
            throw new ArgumentException("A data de compra não pode ser maior que a data atual.");
    }
}