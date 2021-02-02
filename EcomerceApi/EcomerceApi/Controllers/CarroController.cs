using EcomerceApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EcomerceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarroController : ControllerBase
  {
    private readonly CursodbContext dbContext;

    public CarroController(CursodbContext context)
    {
      dbContext = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Carro>> Get()
    {
      var datos = dbContext.Carros.ToArray();
      return Ok(datos);
    }

    [HttpGet("{id}")]
    public ActionResult<Carro> GetById(int id)
    {
      var result = dbContext.Carros.Find(id);
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public ActionResult Post(Carro carro)
    {
      dbContext.Carros.Add(carro);
      dbContext.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { Id = carro.Id }, carro);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var result = dbContext.Carros.Find(id);
      if (result == null)
        return NotFound();

      dbContext.Carros.Remove(result);
      dbContext.SaveChanges();
      return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Carro model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Parametros invalidos");
      }

      var result = dbContext.Carros.Find(id);

      if (result == null)
      {
        return NotFound();
      }

      dbContext.Carros.Update(result);
      result.IdArticulo = model.IdArticulo;
      result.Cantidad = model.Cantidad;      
      dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      dbContext.SaveChanges();
      return Ok();
    }
  }
}
