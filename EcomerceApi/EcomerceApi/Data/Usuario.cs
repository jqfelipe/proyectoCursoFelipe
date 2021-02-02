using System;
using System.Collections.Generic;

#nullable disable

namespace EcomerceApi.Data
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Celular { get; set; }
    }
}
