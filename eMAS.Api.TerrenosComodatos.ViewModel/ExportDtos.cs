using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    public class ExportSingle
    {
        public int Id { get; set; }
        public string ResultRow { get; set; }
    }
    public class ExportSingleResult 
    {
        public short codigoestado { get; set; }
        public string nombrearchivo { get; set; }
        public string contenidoarchivobase64 { get; set; }
        //public byte[] ByteContenidoArchivo { get; set; }
    }
}
