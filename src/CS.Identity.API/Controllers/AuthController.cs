using CS.Identity.Application.Usuario.Dtos;
using CS.Identity.Application.Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS.Identity.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AutenticarUsuarioService _service;

    public AuthController(AutenticarUsuarioService service) => _service = service;

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] AutenticarUsuarioDto dto, CancellationToken ct)
    {
        var result = await _service.ExecutarAsync(dto, ct);
        return Ok(result);
    }
}
