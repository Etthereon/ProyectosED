using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEquipo:IRepositorioEquipo
    {
        private readonly AppContext _appContext;

        public RepositorioEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)
        {
            bool creado=false;
            bool ex= Existe(equipo);
           if(!ex)
           {
                try
                {
                    _appContext.Equipos.Add(equipo);
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

        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            bool actualizado=false;
            var equi=_appContext.Equipos.Find(equipo.id);
            if (equi!=null)
            {
                try
                {
                     equi.Nombre=equipo.Nombre;
                     equi.CantidadDeportistas=equipo.CantidadDeportistas;
                     equi.Disciplina=equipo.Disciplina;
                     equi.PatrocinadorId=equipo.PatrocinadorId;
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
        
        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            bool eliminado=false;
            var Equipo = _appContext.Equipos.Find(idEquipo);
            if (Equipo!=null)
            {
                try
                {
                     _appContext.Equipos.Remove(Equipo);
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
        Equipo IRepositorioEquipo.BuscarEquipo(int idEquipo)
        {
            Equipo Equipo= _appContext.Equipos.Find(idEquipo);
            return Equipo;
        }

        IEnumerable<Equipo> IRepositorioEquipo.ListarEquipos()
        {
            return _appContext.Equipos;
        }

        bool Existe(Equipo equi)
        {
            bool ex=false;
            var equ=_appContext.Equipos.FirstOrDefault(e=> e.Nombre==equi.Nombre);
            if(equ!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}