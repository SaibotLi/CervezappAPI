using Cervezapp.Models;
using Cervezapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cervezapp.Controllers;

[ApiController] // Valida datos y controla las respuestas.
[Route("api/[controller]")] // En que URL va a correr el controller
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

[HttpPost] // Crear cerveza
public ActionResult<Cerveza> PostCerveza(CervezaInsert cervezaInsert) // Parámetro para a futuro insertar valores
{
    var maxCervezaId = CervezaDataStore.Current.Cervezas.Max(x => x.Id); // Storeo la última ID 

    var cervezaNuevo = new Cerveza() {
        Id = maxCervezaId + 1,
        Name = cervezaInsert.Name,
        Description = cervezaInsert.Description,
    };
    
    CervezaDataStore.Current.Cervezas.Add(cervezaNuevo); // Añade cervezaNuevo a la DataStore.
    
    return CreatedAtAction(nameof(GetCerveza), // Devuelve la info de la Cerveza
    
    new { cervezaId = cervezaNuevo.Id}, // Storea la nueva ID
    cervezaNuevo 
    );
}

[HttpPut("{cervezaId}")] // Actualizar cerveza

public ActionResult<Cerveza> PutCerveza([FromRoute] int cervezaId, [FromBody] CervezaInsert cervezaInsert) // "FromRoute": El parametro viene de la URL. "FromBody": El parametro viene del body.
{
    var cerveza = CervezaDataStore.Current.Cervezas.FirstOrDefault(x => x.Id == cervezaId);
    if (cerveza == null)
    return NotFound("La cerveza solicitada no existe.");
    
    cerveza.Name = cervezaInsert.Name;
    cerveza.Description = cervezaInsert.Description;
    return NoContent();
}
}