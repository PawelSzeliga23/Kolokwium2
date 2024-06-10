namespace Kolokwium2.DTO_s;

public class ClientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public IEnumerable<SubsDto> Subscriptions { get; set; }
}