using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EcomerceApi.Data
{
  public partial class MedioPago
  {
    public MedioPago()
    {
      Ordenes = new HashSet<Ordene>();
    }

    public int Id { get; set; }
    public decimal NumeroTarjeta { get; set; }
    public string Titular { get; set; }
    public string Vencimiento { get; set; }
    public int? Cvv { get; set; }
    public string Marca { get; set; }
    public int IdUsuario { get; set; }

    [JsonIgnore]
    public virtual ICollection<Ordene> Ordenes { get; set; }
  }
}
