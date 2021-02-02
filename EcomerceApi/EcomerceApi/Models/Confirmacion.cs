using EcomerceApi.Data;
using System.Collections.Generic;

namespace EcomerceApi.Models
{
  public class Confirmacion
  {
    public string Correo { get; set; }   
    public int Estado { get; set; }
    public string Factura { get; set; }
    public string Direccion { get; set; }
    public int IdPago { get; set; }
    public decimal Monto { get; set; }
    public List<OrdenDto> Ordenes { get; set; }
  }
}
