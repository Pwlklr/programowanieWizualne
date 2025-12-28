using _156023_155875.ProgWiz.CORE;
using System.ComponentModel.DataAnnotations;

public class WebShoeDto : _156023_155875.ProgWiz.INTERFACES.IClimbingShoe
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Wybór producenta jest wymagany")]
    [Range(1, int.MaxValue, ErrorMessage = "Wybierz poprawnego producenta")]
    public int ProducerId { get; set; }

    [Required(ErrorMessage = "Nazwa modelu jest wymagana")]
    [MinLength(3, ErrorMessage = "Nazwa musi mieć co najmniej 3 znaki")]
    [MaxLength(100, ErrorMessage = "Nazwa jest zbyt długa")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Rok produkcji jest wymagany")]
    [Range(1900, 2100, ErrorMessage = "Rok musi być w przedziale 1900-2100")]
    public int ProductionYear { get; set; }

    [Required(ErrorMessage = "Typ zapięcia jest wymagany")]
    public ClosureType Closure { get; set; }

    [Required(ErrorMessage = "Rozmiar jest wymagany")]
    [Range(30, 50, ErrorMessage = "Rozmiar musi być w przedziale 30-50")]
    public double Size { get; set; }
}