using System.Collections;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Interfaces;
using Security.Services;
using Security.Utils;

namespace Security.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service) 
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsers()
    {
        return HttpUtils.CreateHttpResponse<OkResult>(await _service.GetUsers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsersById(String id)
    {
        return HttpUtils.CreateHttpResponse<OkResult>(await _service.GetUserById(id));
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(Usuario user)
    {

        
        try {
            string confirm = await _service.CreateUser(user);
            if (confirm != "OK")
            {
                return HttpUtils.CreateHttpResponse<BadRequestResult>(confirm);
            }
            return HttpUtils.CreateHttpResponse<OkResult>("¡Usuario creado con exito!");
        } catch (Exception e) {
            Console.WriteLine(e);
            return HttpUtils.CreateHttpResponse<BadRequestResult>("Error en el servidor");
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(string id, Usuario user) 
    {
        if (id != user.UsuarioId) return HttpUtils.CreateHttpResponse<BadRequestResult>("No coinciden los IDs");
        
        string confirm = await _service.UpdateUser(user);
        return confirm  == "OK" 
        ? HttpUtils.CreateHttpResponse<OkResult>("Usuario actualizado.") 
        : HttpUtils.CreateHttpResponse<BadRequestResult>(confirm);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(string id)
    {
        string confirm = await _service.DeleteUser(id);
        return confirm != "OK" 
        ? HttpUtils.CreateHttpResponse<BadRequestResult>(confirm)
        : HttpUtils.CreateHttpResponse<OkResult>("Usuario eliminado.");

    }
}