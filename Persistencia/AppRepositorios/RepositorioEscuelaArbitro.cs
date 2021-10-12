using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEscuelaArbitro:IRepositorioEscuelaArbitro
    {
        private readonly AppContext _appContext;

        public RepositorioEscuelaArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioEscuelaArbitro.CrearEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool creado=false;
            bool ex= Existe(escuelaArbitro);
           if(!ex)
           {
                try
                {
                    _appContext.EscuelaArbitros.Add(escuelaArbitro);
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

        bool IRepositorioEscuelaArbitro.ActualizarEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool actualizado=false;
            var arb=_appContext.EscuelaArbitros.Find(escuelaArbitro.id);
            if (arb!=null)
            {
                try
                {
                     arb.Nombre=escuelaArbitro.Nombre;
                     arb.Resolucion=escuelaArbitro.Resolucion;
                     arb.Direccion=escuelaArbitro.Direccion;
                     arb.Telefono=escuelaArbitro.Telefono;
                     arb.Correo=escuelaArbitro.Correo;
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
        
        bool IRepositorioEscuelaArbitro.EliminarEscuelaArbitro(int idEscuelaArbitro)
        {
            bool eliminado=false;
            var EscuelaArbitro = _appContext.EscuelaArbitros.Find(idEscuelaArbitro);
            if (EscuelaArbitro!=null)
            {
                try
                {
                     _appContext.EscuelaArbitros.Remove(EscuelaArbitro);
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
        EscuelaArbitro IRepositorioEscuelaArbitro.BuscarEscuelaArbitro(int idEscuelaArbitro)
        {
            EscuelaArbitro EscuelaArbitro= _appContext.EscuelaArbitros.Find(idEscuelaArbitro);
            return EscuelaArbitro;
        }

        IEnumerable<EscuelaArbitro> IRepositorioEscuelaArbitro.ListarEscuelaArbitros()
        {
            return _appContext.EscuelaArbitros;
        }

        List<EscuelaArbitro> IRepositorioEscuelaArbitro.ListarEscuelaArbitros1()
        {
            return _appContext.EscuelaArbitros.ToList();
        }

        bool Existe(EscuelaArbitro esc)
        {
            bool ex=false;
            var arb=_appContext.EscuelaArbitros.FirstOrDefault(e=> e.Resolucion==esc.Resolucion);
            if(arb!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}