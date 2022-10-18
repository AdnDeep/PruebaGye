using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcCatalogoConfiguracion
    {
        public SmcCatalogoConfiguracion()
        {
        }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Proceso { get; set; }
        public string SubProceso { get; set; }
        public string ClaveBusqueda1 { get; set; }
        public string ClaveBusqueda2 { get; set; }
        public string ValorAlfaNumerico1 { get; set; }
        public string ValorAlfaNumerico2 { get; set; }
        public int ValorEntero1 { get; set; }
        public int ValorEntero2 { get; set; }
    }
}
