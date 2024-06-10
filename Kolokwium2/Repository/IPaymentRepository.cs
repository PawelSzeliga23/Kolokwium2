using Kolokwium2.Controllers;

namespace Kolokwium2.Repository;

public interface IPaymentRepository
{
    public Task<int> PostPaymentAsync(PaymentDto paymentDto);
    Task<bool> CheckIfClientPayed(int IdClient,int IdSub);
}