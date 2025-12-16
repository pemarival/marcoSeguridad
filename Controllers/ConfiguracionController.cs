using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfiguracionController : ControllerBase
{
    public ConfiguracionController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<Configuracion>> GetAll() =>
        ConfiguracionService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Configuracion> Get(int id)
    {
        var configuracion = ConfiguracionService.Get(id);

        if (configuracion == null)
            return NotFound();

        return configuracion;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Configuracion configuracion)
    {
        ConfiguracionService.Add(configuracion);

        return CreatedAtAction(
            nameof(Get),
            new { id = configuracion.ConfiguracionID },
            configuracion
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Configuracion configuracion)
    {
        if (id != configuracion.ConfiguracionID)
            return BadRequest();

        var existing = ConfiguracionService.Get(id);
        if (existing is null)
            return NotFound();

        ConfiguracionService.Update(configuracion);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var configuracion = ConfiguracionService.Get(id);
        if (configuracion is null)
            return NotFound();

        ConfiguracionService.Delete(id);
        return NoContent();
    }
}
