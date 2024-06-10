using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Controllers;

public class PaymentDto
{
    [Required]
    public int IdClient { get; set; }
    [Required]
    public int IdSubscription { get; set; }
    [Required]
    public decimal Payment { get; set; }
}