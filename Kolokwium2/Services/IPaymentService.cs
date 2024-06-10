using Kolokwium2.Controllers;

namespace Kolokwium2.Services;

public interface IPaymentService
{
    public Task<int> PostPaymentAsync(PaymentDto paymentDto);
}