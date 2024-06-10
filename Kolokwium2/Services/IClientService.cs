using Kolokwium2.DTO_s;
using Kolokwium2.Models;

namespace Kolokwium2.Services;

public interface IClientService
{
    public Task<ClientDTO> GetClientByIdAsync(int id);
}