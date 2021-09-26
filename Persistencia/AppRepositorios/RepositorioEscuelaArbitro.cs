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
            return creado;
        }

        bool IRepositorioEscuelaArbitro.ActualizarEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool actualizado=false;
            var arb=_appContext.EscuelaArbitros.Find(4);
            if (arb!=null)
            {
                try
                {
                     arb.Nombre=escuelaArbitro.Nombre;
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

    }
}