using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcBeneficiarioPaginado
    {
        public SmcBeneficiarioPaginado()
        {
        }

        public short IdBeneficiario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string NombreRepresentante { get; set; }
        public string Contacto { get; set; }
        public bool PdpEstado { get; set; }
    }
}
