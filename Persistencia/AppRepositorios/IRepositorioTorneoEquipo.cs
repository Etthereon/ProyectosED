using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneoEquipo
    {
        IEnumerable<TorneoEquipo> ListarTorneoEquipos();
        bool CrearTorneoEquipo(TorneoEquipo torneoEquipo);
        bool EliminarTorneoEquipo(int TorneoId, int EquipoId);
        TorneoEquipo BuscarTorneoEquipo(int TorneoId, int EquipoId);
    }
}