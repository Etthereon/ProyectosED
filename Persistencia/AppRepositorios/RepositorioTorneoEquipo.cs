using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioTorneoEquipo:IRepositorioTorneoEquipo
    {
        private readonly AppContext _appContext;

        public RepositorioTorneoEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioTorneoEquipo.CrearTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool creado=false;
            bool ex = Existe(torneoEquipo);
            if(!ex)
            {
                try
                {
                    _appContext.TorneoEquipos.Add(torneoEquipo);
                    _appContext.SaveChanges();
                    creado=true;
                }
                catch (System.Exception)
                {
                    return creado;
                    //throw;
                }
            }
                return creado;
        }

        public bool EliminarTorneoEquipo(int IdTor, int IdEqu)
        {
            bool eliminado=false;
            var torequ=_appContext.TorneoEquipos.FirstOrDefault(t=> t.TorneoId==IdTor && t.EquipoId==IdEqu);
            if (torequ!=null)
            {
                try
                {
                     _appContext.TorneoEquipos.Remove(torequ);
                     _appContext.SaveChanges();
                     eliminado=true;
                }
                catch (System.Exception)
                {
                    
                    return eliminado;
                }
            }
            return eliminado;
        }

        TorneoEquipo IRepositorioTorneoEquipo.BuscarTorneoEquipo(int IdTor, int IdEqu)
        {
            TorneoEquipo TorneoEquipo= _appContext.TorneoEquipos.FirstOrDefault(t=> t.TorneoId==IdTor && t.EquipoId==IdEqu);
            return TorneoEquipo;
        }

        IEnumerable<TorneoEquipo> IRepositorioTorneoEquipo.ListarTorneoEquipos()
        {
            return _appContext.TorneoEquipos;
        }

        bool Existe(TorneoEquipo torequ)
        {
            bool ex=false;
            var te=_appContext.TorneoEquipos.FirstOrDefault(t=> t.TorneoId==torequ.TorneoId && t.EquipoId==torequ.EquipoId);
            if(te!=null)
            {
                ex=true;
            }
            return ex;
        }
    }
}