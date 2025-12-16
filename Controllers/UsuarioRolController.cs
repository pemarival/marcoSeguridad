using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioRolController : ControllerBase
{
    // GET ALL
    [HttpGet]
    public ActionResult<List<UsuarioRol>> GetAll() =>
        UsuarioRolService.GetAll();

    // GET BY COMPOSITE KEY
    [HttpGet("{usuarioId}/{rolId}")]
    public ActionResult<UsuarioRol> Get(int usuarioId, int rolId)
    {
        var usuarioRol = UsuarioRolService.Get(usuarioId, rolId);

        if (usuarioRol is null)
            return NotFound();

        return usuarioRol;
    }

    // POST
    [HttpPost]
    public IActionResult Create(UsuarioRol usuarioRol)
    {
        UsuarioRolService.Add(usuarioRol);
        return CreatedAtAction(
            nameof(Get),
            new { usuarioId = usuarioRol.UsuarioID, rolId = usuarioRol.RolID },
            usuarioRol
        );
    }

    // PUT
    [HttpPut("{usuarioId}/{rolId}")]
    public IActionResult Update(int usuarioId, int rolId, UsuarioRol usuarioRol)
    {
        if (usuarioId != usuarioRol.UsuarioID || rolId != usuarioRol.RolID)
            return BadRequest();

        var existing = UsuarioRolService.Get(usuarioId, rolId);
        if (existing is null)
            return NotFound();

        UsuarioRolService.Update(usuarioRol);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{usuarioId}/{rolId}")]
    public IActionResult Delete(int usuarioId, int rolId)
    {
        var usuarioRol = UsuarioRolService.Get(usuarioId, rolId);
        if (usuarioRol is null)
            return NotFound();

        UsuarioRolService.Delete(usuarioId, rolId);
        return NoContent();
    }
}
