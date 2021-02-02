using EcomerceApi.Data;
using EcomerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EcomerceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdenesController : ControllerBase
  {
    private readonly CursodbContext dbContext;

    public OrdenesController(CursodbContext context)
    {
      dbContext = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Orden>> Get()
    {
      var datos = dbContext.Ordenes.ToArray();
      return Ok(datos);
    }

    [HttpGet("{id}")]
    public ActionResult<Orden> GetById(int id)
    {
      var result = dbContext.Ordenes.Find(id);
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public ActionResult Post(Confirmacion orden)
    {
      var compraModel = new CompraModels(dbContext);
      compraModel.ProcesarOrden(orden);    
      return CreatedAtAction(nameof(GetById), new { Id = orden.IdPago }, orden);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var result = dbContext.Ordenes.Find(id);
      if (result == null)
        return NotFound();

      dbContext.Ordenes.Remove(result);
      dbContext.SaveChanges();
      return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Orden model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Parametros invalidos");
      }

      var result = dbContext.Ordenes.Find(id);

      if (result == null)
      {
        return NotFound();
      }

      dbContext.Ordenes.Update(result);
      result.Estado = model.Estado;      
      dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      dbContext.SaveChanges();
      return Ok();
    }
  }
}
