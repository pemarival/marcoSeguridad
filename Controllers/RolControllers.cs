using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class RolController : ControllerBase
{
    public RolController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<Rol>> GetAll() =>
        RolService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Rol> Get(int id)
    {
        var rol = RolService.Get(id);

        if (rol == null)
            return NotFound();

        return rol;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Rol rol)
    {
        RolService.Add(rol);
        return CreatedAtAction(
            nameof(Get),
            new { id = rol.RolID },
            rol
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Rol rol)
    {
        if (id != rol.RolID)
            return BadRequest();

        var existing = RolService.Get(id);
        if (existing is null)
            return NotFound();

        RolService.Update(rol);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var rol = RolService.Get(id);
        if (rol is null)
            return NotFound();

        RolService.Delete(id);
        return NoContent();
    }
}
