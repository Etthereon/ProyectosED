using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneoEquipo
    {
        IEnumerable<TorneoEquipo> ListarTorneoEquipos();
        bool CrearTorneoEquipo(TorneoEquipo torneoEquipo);
        bool EliminarTorneoEquipo(int IdTor, int IdEqu);
        TorneoEquipo BuscarTorneoEquipo(int IdTor, int IdEqu);
    }
}