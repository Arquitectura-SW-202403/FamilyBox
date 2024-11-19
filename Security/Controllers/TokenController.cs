using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Security.Interfaces;
using Security.Utils;

namespace Security.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IUserService _service;

    public TokenController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult> GenerateToken()
    {
        var header = Request.Headers.Authorization;
        
        Console.WriteLine(header);

        if (header == "") {
            return HttpUtils.CreateHttpResponse<BadRequestResult>("No basic header present.");
        }

        Username username = HttpUtils.DecodeBasicAuth(header.ToString());

        Usuario? user = await _service.GetUserById(username.user);

        if (user == null) {
            return HttpUtils.CreateHttpResponse<BadRequestResult>("No existe el usuario.");
        }

        if (!SecurityUtils.VerifyHash(username.password, user.Password!))
        {
            return HttpUtils.CreateHttpResponse<BadRequestResult>("Hay algo mal en la información.");
        }

        var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.UsuarioId!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Name, user.Nombre!),
            new Claim(ClaimTypes.Role, user.TipoUsuario.ToString())
        };

        var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!)
                ),
                SecurityAlgorithms.HmacSha256Signature
            )
        );

        return HttpUtils.CreateHttpResponse<OkResult>(
            new {
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                user = new {
                    nombre = user.Nombre,
                    id = user.UsuarioId,
                    rol = user.TipoUsuario.ToString(),
                    tipoDocumento = user.TipoDocumento,
                    email = user.Email,
                    telefono = user.Telefono,
                    fechaRegistro = user.FechaRegistro,
                    estado = user.Estado
                }
            }
        );
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(Usuario user)
    {
        user.Password = SecurityUtils.HashString(user.Password!);
        string confirm = await _service.CreateUser(user);
        return confirm == "OK"
        ? HttpUtils.CreateHttpResponse<OkResult>("Ya puedes hacer login.")
        : HttpUtils.CreateHttpResponse<BadRequestResult>(confirm);
    }

    [HttpPost("validate")]
    public async Task<ActionResult> ValidateToken(TokenValidation validation)
    {
        var validationParameter = new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8
                .GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!)
            ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = false,
        };

        try {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validatedToken = await tokenHandler.ValidateTokenAsync(validation.token, validationParameter);
            return validatedToken.IsValid 
            ? HttpUtils.CreateHttpResponse<OkResult>(validatedToken.Claims) 
            : HttpUtils.CreateHttpResponse<BadRequestResult>("El token no es valido");
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
            return HttpUtils.CreateHttpResponse<ActionResult>("Sucedió un error.", 500);
        }
    }
}