namespace Kolokwium2.Models;

public class Client
{
    public int IdCleint { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}