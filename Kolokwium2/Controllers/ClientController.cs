using Kolokwium2.Exception;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientByIdAsync(int id)
    {
        try
        {
            var res = await _clientService.GetClientByIdAsync(id);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}