namespace Kolokwium2.Models;

public class Payment
{
    public int IdPayment { get; set; }
    public DateTime Date { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    public Client IdClientNavigation { get; set; }
    public Subscription IdSubNavigation { get; set; }
}