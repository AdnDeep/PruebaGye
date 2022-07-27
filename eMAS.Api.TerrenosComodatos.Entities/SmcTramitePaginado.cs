using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTramitePaginado
    {
        public SmcTramitePaginado()
        {
        }

        public short IdTramite { get; set; }
        public short Anio { get; set; }
        public short Secuencia { get; set; }
        public short IdSector { get; set; }
        public short Manzana { get; set; }
        public short Lote { get; set; }
        public short Division { get; set; }
        public short Phv { get; set; }
        public short Phh { get; set; }
        public short Numero { get; set; }
        public short IdBeneficiario { get; set; }
        public string NombreBeneficiario { get; set; }
        public string Identificacion { get; set; }
        public short IdEstado { get; set; }
        public string DescripcionEstado { get; set; }
    }
}
