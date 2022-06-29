using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioEliminacionTramites
    {
        void Eliminar();
        void EliminarAnexo();
        void EliminarObservacion();
        void EliminarTopografiaTerreno();
        void EliminarSeguimientoOficio();
    }
}
