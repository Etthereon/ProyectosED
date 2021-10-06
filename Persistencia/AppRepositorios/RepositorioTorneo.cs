using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioTorneo:IRepositorioTorneo
    {
        private readonly AppContext _appContext;

        public RepositorioTorneo(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)
        {
            bool creado=false;
             bool ex= Existe(torneo);
            if(!ex)
            {
                try
                {
                    _appContext.Torneos.Add(torneo);
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

        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado=false;
            var tor=_appContext.Torneos.Find(torneo.id);
            if (tor!=null)
            {
                try
                {
                     tor.Nombre=torneo.Nombre;
                     tor.Categoria=torneo.Categoria;
                     tor.FechaInicial=torneo.FechaInicial;
                     tor.FechaFinal=torneo.FechaFinal;
                     tor.Tipo=torneo.Tipo;
                     tor.MunicipioId=torneo.MunicipioId;
                     _appContext.SaveChanges();
                     actualizado=true;
                }
                catch (System.Exception)
                {
                    
                    return actualizado;
                }
            }
            return actualizado;
        }
        
        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado=false;
            var Torneo = _appContext.Torneos.Find(idTorneo);
            if (Torneo!=null)
            {
                try
                {
                     _appContext.Torneos.Remove(Torneo);
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
        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            Torneo Torneo= _appContext.Torneos.Find(idTorneo);
            return Torneo;
        }

        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.Torneos;
        }

         bool Existe(Torneo torn)
        {
            bool ex=false;
            var tor=_appContext.Torneos.FirstOrDefault(t=> t.Nombre==torn.Nombre);
            if(tor!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}