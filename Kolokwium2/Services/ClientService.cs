using Kolokwium2.DTO_s;
using Kolokwium2.Repository;

namespace Kolokwium2.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientDTO> GetClientByIdAsync(int id)
    {
        return await _clientRepository.GetClientByIdAsync(id);
    }
}