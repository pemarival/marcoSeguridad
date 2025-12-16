using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class RolPermisoController : ControllerBase
{
    public RolPermisoController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<RolPermiso>> GetAll() =>
        RolPermisoService.GetAll();

    // GET by RolID + PermisoID
    [HttpGet("{rolId}/{permisoId}")]
    public ActionResult<RolPermiso> Get(int rolId, int permisoId)
    {
        var rolPermiso = RolPermisoService.Get(rolId, permisoId);

        if (rolPermiso == null)
            return NotFound();

        return rolPermiso;
    }

    // POST
    [HttpPost]
    public IActionResult Create(RolPermiso rolPermiso)
    {
        RolPermisoService.Add(rolPermiso);
        return CreatedAtAction(
            nameof(Get),
            new
            {
                rolId = rolPermiso.RolID,
                permisoId = rolPermiso.PermisoID
            },
            rolPermiso
        );
    }

    // PUT
    [HttpPut("{rolId}/{permisoId}")]
    public IActionResult Update(int rolId, int permisoId, RolPermiso rolPermiso)
    {
        if (rolId != rolPermiso.RolID || permisoId != rolPermiso.PermisoID)
            return BadRequest();

        var existing = RolPermisoService.Get(rolId, permisoId);
        if (existing is null)
            return NotFound();

        RolPermisoService.Update(rolPermiso);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{rolId}/{permisoId}")]
    public IActionResult Delete(int rolId, int permisoId)
    {
        var rolPermiso = RolPermisoService.Get(rolId, permisoId);
        if (rolPermiso is null)
            return NotFound();

        RolPermisoService.Delete(rolId, permisoId);
        return NoContent();
    }
}
