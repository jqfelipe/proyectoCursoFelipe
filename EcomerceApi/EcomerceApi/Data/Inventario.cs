using System;
using System.Collections.Generic;

#nullable disable

namespace EcomerceApi.Data
{
    public partial class Inventario
    {
        public int Id { get; set; }
        public int Existencias { get; set; }
        public string Categoria { get; set; }

        public virtual Articulo IdNavigation { get; set; }
    }
}
