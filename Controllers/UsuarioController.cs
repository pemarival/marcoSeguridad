using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    public UsuarioController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<Usuario>> GetAll() =>
        UsuarioService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Usuario> Get(int id)
    {
        var usuario = UsuarioService.Get(id);

        if (usuario == null)
            return NotFound();

        return usuario;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Usuario usuario)
    {
        UsuarioService.Add(usuario);
        return CreatedAtAction(
            nameof(Get),
            new { id = usuario.UsuarioID },
            usuario
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Usuario usuario)
    {
        if (id != usuario.UsuarioID)
            return BadRequest();

        var existing = UsuarioService.Get(id);
        if (existing is null)
            return NotFound();

        UsuarioService.Update(usuario);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = UsuarioService.Get(id);
        if (usuario is null)
            return NotFound();

        UsuarioService.Delete(id);
        return NoContent();
    }
}
