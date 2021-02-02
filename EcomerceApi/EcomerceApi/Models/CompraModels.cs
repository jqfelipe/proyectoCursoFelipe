using EcomerceApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcomerceApi.Models
{
  public class CompraModels
  {
    private readonly CursodbContext dbContext;
    public CompraModels(CursodbContext context)
    {
      dbContext = context;
    }

    public void CrearOrden(Orden orden)
    {
      dbContext.Ordenes.Add(orden);
      dbContext.SaveChanges();
    }

    public IEnumerable<Carro> ObtenerCarro(string correo)
    {
      var result = dbContext.Carros.Where(p => p.Correo.Equals(correo));
      if (result.Any())
        return result.ToArray();
      else
        return new List<Carro>();
    }

    public void ProcesarOrden(Confirmacion confirmacion)
    {
      var arrCarro = ObtenerCarro(confirmacion.Correo);
      if (!arrCarro.Any())
        throw new InvalidOperationException("No se encontro el carrito");

      foreach (var item in confirmacion.Ordenes)
      {
        var carro = arrCarro.FirstOrDefault(p => p.IdArticulo.Equals(item.IdArticulo));
        if (carro != null)
        {
          var orden = new Orden
          {
            Factura = confirmacion.Factura,
            Cantidad = item.Cantidad,
            IdArticulo = item.IdArticulo,
            Correo = confirmacion.Correo,
            Direccion = confirmacion.Direccion,
            Estado = 1,
            IdPago = confirmacion.IdPago,
            Monto = confirmacion.Monto
          };
          dbContext.Ordenes.Add(orden);
          dbContext.Carros.Remove(carro);
          dbContext.SaveChanges();
        }
      }


    }
  }
}
