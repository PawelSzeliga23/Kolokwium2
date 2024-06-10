using Kolokwium2.DTO_s;
using Kolokwium2.Models;

namespace Kolokwium2.Repository;

public interface IClientRepository
{
    public Task<ClientDTO> GetClientByIdAsync(int id);
    public Task<Client> CheckIfClientExist(int id);
}