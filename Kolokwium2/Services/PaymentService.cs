using Kolokwium2.Context;
using Kolokwium2.Controllers;
using Kolokwium2.Exception;
using Kolokwium2.Repository;

namespace Kolokwium2.Services;

public class PaymentService : IPaymentService
{
    private readonly MyDbContext _context;
    private readonly IClientRepository _clientRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ISubscriptionRepository _subscriptionRepository;

    public PaymentService(MyDbContext context, IClientRepository clientRepository, IPaymentRepository paymentRepository,
        ISubscriptionRepository subscriptionRepository)
    {
        _context = context;
        _clientRepository = clientRepository;
        _paymentRepository = paymentRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<int> PostPaymentAsync(PaymentDto paymentDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var client = await _clientRepository.CheckIfClientExist(paymentDto.IdClient);
            var sub = await _subscriptionRepository.CheckIfExist(paymentDto.IdSubscription);
            if (sub.EndTime < DateTime.Now)
            {
                throw new BadRequestException("Sub is invalid date expired");
            }

            await _paymentRepository.CheckIfClientPayed(paymentDto.IdClient, paymentDto.IdSubscription);
            if (sub.Price > paymentDto.Payment)
            {
                throw new BadRequestException("Not enough money");
            }

            //Zniżka
            var id = await _paymentRepository.PostPaymentAsync(paymentDto);
            await transaction.CommitAsync();
            return id;
        }
        catch (NotFoundException e)
        {
            await transaction.RollbackAsync();
            throw new NotFoundException(e.Message);
        }
        catch (BadRequestException e)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(e.Message);
        }
        catch (System.Exception e)
        {
            await transaction.RollbackAsync();
            throw new System.Exception(e.Message);
        }
    }
}