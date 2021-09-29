using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioDeportista:IRepositorioDeportista
    {
        private readonly AppContext _appContext;

        public RepositorioDeportista(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            bool creado=false;
            bool ex= Existe(deportista);
           if(!ex)
           {
                try
                {
                    _appContext.Deportistas.Add(deportista);
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

        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado=false;
            var dep=_appContext.Deportistas.Find(deportista.id);
            if (dep!=null)
            {
                try
                {
                     dep.Documento=deportista.Documento;
                     dep.Nombres=deportista.Nombres;
                     dep.Apellidos=deportista.Apellidos;
                     dep.Genero=deportista.Genero;
                     dep.Rh=deportista.Rh;
                     dep.EPS=deportista.EPS;
                     dep.FechaNac=deportista.FechaNac;
                     dep.Disciplina=deportista.Disciplina;
                     dep.Direccion=deportista.Direccion;
                     dep.NumeroEmergencia=deportista.NumeroEmergencia;
                     dep.EquipoId=deportista.EquipoId;
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
        
        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            bool eliminado=false;
            var Deportista = _appContext.Deportistas.Find(idDeportista);
            if (Deportista!=null)
            {
                try
                {
                     _appContext.Deportistas.Remove(Deportista);
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
        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            Deportista Deportista= _appContext.Deportistas.Find(idDeportista);
            return Deportista;
        }

        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _appContext.Deportistas;
        }

        bool Existe(Deportista depor)
        {
            bool ex=false;
            var dep=_appContext.Deportistas.FirstOrDefault(d=> d.Documento==depor.Documento);
            if(dep!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}