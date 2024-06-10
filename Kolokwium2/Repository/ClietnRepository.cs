using Kolokwium2.Context;
using Kolokwium2.DTO_s;
using Kolokwium2.Exception;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Repository;

public class ClientRepository : IClientRepository
{
    private readonly MyDbContext _context;

    public ClientRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<ClientDTO> GetClientByIdAsync(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.IdCleint == id);
        if (client == null)
        {
            throw new NotFoundException("Client Not Found");
        }

        var subs = await _context.Sales.Where(s => s.IdClient == id)
            .Select(s => new SubsDto()
            {
                IdSubscription = s.IdSubNavigation.IdSubscription,
                Name = s.IdSubNavigation.Name,
                TotalPaidAmount =
                    _context.Payments
                        .Where(p => p.IdSubscription == s.IdSubNavigation.IdSubscription && p.IdClient == id).ToList()
                        .Count * s.IdSubNavigation.Price
            }).ToListAsync();
        var res = new ClientDTO()
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone ?? "",
            Subscriptions = subs
        };
        return res;
    }

    public async Task<Client> CheckIfClientExist(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.IdCleint == id);
        if (client == null)
        {
            throw new NotFoundException("Client Not Found");
        }

        return client;
    }
}