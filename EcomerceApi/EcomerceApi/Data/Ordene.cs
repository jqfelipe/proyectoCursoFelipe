using System;
using System.Collections.Generic;

#nullable disable

namespace EcomerceApi.Data
{
    public partial class Ordene
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

        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual MedioPago IdPagoNavigation { get; set; }
    }
}
