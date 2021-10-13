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

        /*bool IRepositorioTorneoEquipo.ActualizarTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool actualizado=false;
            var torneoeq=_appContext.TorneoEquipos.Find(4);
            if (torneoeq!=null)
            {
                try
                {
                     torneoeq.TorneoId=torneoEquipo.TorneoId;
                     _appContext.SaveChanges();
                     actualizado=true;
                }
                catch (System.Exception)
                {
                    
                    return actualizado;
                }
            }
            return actualizado;
        }*/
        
        bool IRepositorioTorneoEquipo.EliminarTorneoEquipo(int TorneoId, int EquipoId)
        {
            bool eliminado=false;
            var TorneoEquipo = _appContext.TorneoEquipos.Find(TorneoId, EquipoId);
            if (TorneoEquipo!=null)
            {
                try
                {
                     _appContext.TorneoEquipos.Remove(TorneoEquipo);
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
        TorneoEquipo IRepositorioTorneoEquipo.BuscarTorneoEquipo(int TorneoId, int EquipoId)
        {
            TorneoEquipo TorneoEquipo= _appContext.TorneoEquipos.Find(TorneoId, EquipoId);
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