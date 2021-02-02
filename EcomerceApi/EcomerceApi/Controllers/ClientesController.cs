using EcomerceApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EcomerceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClientesController : ControllerBase
  {
    private readonly CursodbContext dbContext;

    public ClientesController(CursodbContext context) 
    {
      dbContext = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> Get() 
    {
      var datos = dbContext.Usuarios.ToArray();
      return Ok(datos);
    }

    [HttpGet("{id}")]
    public ActionResult<Usuario> GetById(int id)
    {
      var result = dbContext.Usuarios.Find(id);
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public ActionResult Post(Usuario usuario)
    {
      dbContext.Usuarios.Add(usuario);
      dbContext.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { Id = usuario.Id}, usuario);      
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var result = dbContext.Usuarios.Find(id);
      if (result == null)
        return NotFound();

      dbContext.Usuarios.Remove(result);
      dbContext.SaveChanges();
      return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Usuario model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Parametros invalidos");
      }

      var result = dbContext.Usuarios.Find(id);

      if (result == null)
      {
        return NotFound();
      }

      dbContext.Usuarios.Update(result);
      result.Celular = model.Celular;
      result.CorreoElectronico = model.CorreoElectronico;
      result.Nombre = string.IsNullOrWhiteSpace(model.Nombre)? result.Nombre : model.Nombre;
      dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      dbContext.SaveChanges();      
      return Ok();
    }
  }
}
