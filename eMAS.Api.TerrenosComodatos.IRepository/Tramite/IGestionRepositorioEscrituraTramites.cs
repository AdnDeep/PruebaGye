using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioEscrituraTramites
    {
        void Agregar();
        void Actualizar();
        void AgregarAnexo();
        void ActualizarAnexo();
        void AgregarObservacion();
        void ActualizarObservacion();
        void AgregarTopografiaTerreno();
        void ActualizarTopografiaTerreno();
        void AgregarSeguimientoOficio();
        void ActualizarSeguimientoOficio();
    }
}
