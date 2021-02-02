using EcomerceApi.Data;
using EcomerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EcomerceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductosController : ControllerBase
  {
    private readonly CursodbContext dbContext;

    public ProductosController(CursodbContext context)
    {
      dbContext = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Articulo>> Get()
    {
      var datos = dbContext.Articulos.ToArray();
      return Ok(datos);
    }

    [HttpGet("{id}")]
    public ActionResult<Articulo> GetById(int id)
    {
      var result = dbContext.Articulos.Find(id);
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public ActionResult Post(Producto producto)
    {
      var articulo = new Articulo 
      {
        Id = producto.Id,
        Descripcion = producto.Descripcion,
        UrlImagen = producto.UrlImagen,
        Valor = producto.Valor        
      };
      dbContext.Articulos.Add(articulo);
      dbContext.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { Id = articulo.Id }, articulo);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var result = dbContext.Articulos.Find(id);
      if (result == null)
        return NotFound();

      dbContext.Articulos.Remove(result);
      dbContext.SaveChanges();
      return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Articulo model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Parametros invalidos");
      }

      var result = dbContext.Articulos.Find(id);

      if (result == null)
      {
        return NotFound();
      }

      dbContext.Articulos.Update(result);
      result.Descripcion = model.Descripcion;
      result.UrlImagen = model.UrlImagen;
      result.Valor = model.Valor;
      dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      dbContext.SaveChanges();
      return Ok();
    }
  }
}
