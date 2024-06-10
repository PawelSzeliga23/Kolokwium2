using Kolokwium2.Context;
using Kolokwium2.Controllers;
using Kolokwium2.Exception;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly MyDbContext _context;

    public PaymentRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<int> PostPaymentAsync(PaymentDto paymentDto)
    {
        var payment = new Payment()
        {
            Date = DateTime.Now,
            IdClient = paymentDto.IdClient,
            IdSubscription = paymentDto.IdSubscription
        };
        var entity = await _context.Payments.AddAsync(payment);
        var id = entity.Entity.IdPayment;
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<bool> CheckIfClientPayed(int IdClient, int IdSub)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(p =>
            p.IdClient == IdClient && p.IdSubscription == IdSub && p.Date > DateTime.Now);
        if (payment == null)
        {
            return true;
        }

        throw new BadRequestException("Client Payed");
    }
}