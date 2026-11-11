using CS.Identity.Application.Usuario.Dtos;
using CS.Identity.Application.Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS.Identity.API.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly CriarUsuarioService _service;

    public UsuarioController(CriarUsuarioService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarUsuarioDto dto, CancellationToken ct)
    {
        var id = await _service.ExecutarAsync(dto, ct);
        return CreatedAtAction(nameof(Criar), new { id }, new { id });
    }
}
