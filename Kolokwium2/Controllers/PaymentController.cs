using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> PostPayment(PaymentDto payment)
    {
        try
        {
            var id = _paymentService.PostPaymentAsync(payment);
            //Powinno byc Created ale nie moge id dac 
            return Ok(id);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}