using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        private readonly AppContext _appContext;

        public RepositorioEscenario(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado=false;
            bool ex= Existe(escenario);
            if(!ex)
            {
                try
                {
                    _appContext.Escenarios.Add(escenario);
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

        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado=false;
            var esc=_appContext.Escenarios.Find(escenario.id);
            if (esc!=null)
            {
                try
                {
                     esc.Nombre=escenario.Nombre;
                     esc.Direccion=escenario.Direccion;
                     esc.Telefono=escenario.Telefono;
                     esc.Horario=escenario.Horario;
                     esc.TorneoId=escenario.TorneoId;
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
        
        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado=false;
            var Escenario = _appContext.Escenarios.Find(idEscenario);
            if (Escenario!=null)
            {
                try
                {
                     _appContext.Escenarios.Remove(Escenario);
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
        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            Escenario Escenario= _appContext.Escenarios.Find(idEscenario);
            return Escenario;
        }

        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _appContext.Escenarios;
        }

        List<Escenario> IRepositorioEscenario.ListarEscenarios1()
        {
            return _appContext.Escenarios.ToList();
        }

        bool Existe(Escenario esce)
        {
            bool ex=false;
            var esc=_appContext.Escenarios.FirstOrDefault(e=> e.Nombre==esce.Nombre);
            if(esc!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}