using Kolokwium2.Context;
using Kolokwium2.Exception;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Repository;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly MyDbContext _context;

    public SubscriptionRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Subscription> CheckIfExist(int id)
    {
        var sub = await _context.Subscriptions.FirstOrDefaultAsync(s => s.IdSubscription == id);
        if (sub == null)
        {
            throw new NotFoundException("Subscription Not Found");
        }

        return sub;
    }

    public async Task<bool> CheckIfSubIsValid(int id)
    {
        var sub = await _context.Subscriptions.FirstOrDefaultAsync(s => s.IdSubscription == id);
        if (sub.EndTime > DateTime.Now)
        {
            throw new BadRequestException("Sub is invaild date expired");
        }

        return true;
    }
}

public interface ISubscriptionRepository
{
    public Task<Subscription> CheckIfExist(int id);
    public Task<bool> CheckIfSubIsValid(int id);
}