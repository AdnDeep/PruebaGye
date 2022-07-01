using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcValidaDataServidor
    {
        public SmcValidaDataServidor()
        {
        }
        public string CLAVE { get; set; }
        public bool VALORBOOLEANO { get; set; }
        public int VALORNUMERICO { get; set; }        
    }
}
