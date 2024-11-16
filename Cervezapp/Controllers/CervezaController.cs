using Cervezapp.Models;
using Cervezapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cervezapp.Controllers;

[ApiController] // Valida datos y controla las respuestas. DATA NOTATION [].
[Route("api/[controller]")] //En que URL va a correr
public class CervezaController : ControllerBase
{
[HttpGet] // Obtener todas las cervezas
public ActionResult <IEnumerable<Cerveza>> GetCervezas()
{
    return Ok(CervezaDataStore.Current.Cervezas);
}

[HttpGet("{cervezaId}")] // Obtener cerveza específica
public ActionResult<Cerveza> GetCerveza(int cervezaId)
{
    var cerveza = CervezaDataStore.Current.Cervezas.FirstOrDefault(x => x.Id == cervezaId);
    if (cerveza == null)
    return NotFound("La cerveza solicitada no existe.");
    return Ok(cerveza);
}

[HttpPost] // El usuario podrá crear cervezas
public ActionResult<Cerveza> PostCerveza(CervezaInsert cervezaInsert) // Parámetro para a futuro insertar valores
{
    var maxCervezaId = CervezaDataStore.Current.Cervezas.Max(x => x.Id); // Store de la última ID 

    var cervezaNuevo = new Cerveza() {
        Id = maxCervezaId + 1,
        Name = cervezaInsert.Name,
        Description = cervezaInsert.Description,
    };

    CervezaDataStore.Current.Cervezas.Add(cervezaNuevo);
    return CreatedAtAction(nameof(GetCerveza),
    new { cervezaId = cervezaNuevo.Id},
    cervezaNuevo
    );
}
}