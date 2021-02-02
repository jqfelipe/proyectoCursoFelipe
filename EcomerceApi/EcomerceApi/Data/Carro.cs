using System.Text.Json.Serialization;

#nullable disable

namespace EcomerceApi.Data
{
  public partial class Carro
  {
    public int Id { get; set; }
    public string Correo { get; set; }
    public int IdArticulo { get; set; }
    public int Cantidad { get; set; }


    [JsonIgnore]
    public virtual Articulo IdArticuloNavigation { get; set; }
  }
}
