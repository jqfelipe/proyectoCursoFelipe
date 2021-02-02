using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EcomerceApi.Data
{
  public partial class Orden
  {
    public int Id { get; set; }
    public string Correo { get; set; }
    public int IdArticulo { get; set; }
    public int Cantidad { get; set; }
    public int Estado { get; set; }
    public string Factura { get; set; }
    public string Direccion { get; set; }
    public int IdPago { get; set; }
    public decimal Monto { get; set; }

    [JsonIgnore]
    public virtual Articulo IdArticuloNavigation { get; set; }

    [JsonIgnore]
    public virtual MedioPago IdPagoNavigation { get; set; }
  }
}
