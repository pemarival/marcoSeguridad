using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class LogErrorController : ControllerBase
{
    public LogErrorController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<LogError>> GetAll() =>
        LogErrorService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<LogError> Get(int id)
    {
        var logError = LogErrorService.Get(id);

        if (logError == null)
            return NotFound();

        return logError;
    }

    // POST
    [HttpPost]
    public IActionResult Create(LogError logError)
    {
        LogErrorService.Add(logError);
        return CreatedAtAction(
            nameof(Get),
            new { id = logError.ErrorID },
            logError
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, LogError logError)
    {
        if (id != logError.ErrorID)
            return BadRequest();

        var existing = LogErrorService.Get(id);
        if (existing is null)
            return NotFound();

        LogErrorService.Update(logError);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var logError = LogErrorService.Get(id);
        if (logError is null)
            return NotFound();

        LogErrorService.Delete(id);
        return NoContent();
    }
}
