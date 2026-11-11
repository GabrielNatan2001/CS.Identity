namespace CS.Identity.Application.Usuario.Dtos;

public record AuthResponseDto(string Token, string Email, string Role, Guid UsuarioId);
