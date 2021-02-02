using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EcomerceApi.Data
{
  public partial class Articulo
  {
    public Articulo()
    {
      Carros = new HashSet<Carro>();
      Ordenes = new HashSet<Orden>();
    }

    public int Id { get; set; }
    public string Descripcion { get; set; }
    public string UrlImagen { get; set; }
    public decimal Valor { get; set; }

    [JsonIgnore]
    public virtual Inventario Inventario { get; set; }

    [JsonIgnore]
    public virtual ICollection<Carro> Carros { get; set; }

    [JsonIgnore]
    public virtual ICollection<Orden> Ordenes { get; set; }
  }
}
