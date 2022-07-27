using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcValidacionEscritura
    {
        public SmcValidacionEscritura()
        {
        }
        public string clave { get; set; }
        public short valorNumerico { get; set; }
    }
}
