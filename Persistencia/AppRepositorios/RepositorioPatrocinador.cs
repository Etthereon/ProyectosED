using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioPatrocinador:IRepositorioPatrocinador
    {
        private readonly AppContext _appContext;

        public RepositorioPatrocinador(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado=false;
            bool ex= Existe(patrocinador);
            if(!ex)
            {
                try
                {
                    _appContext.Patrocinadores.Add(patrocinador);
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

        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado=false;
            var pat=_appContext.Patrocinadores.Find(patrocinador.id);
            if (pat!=null)
            {
                try
                {
                     pat.Identificacion=patrocinador.Identificacion;
                     pat.Nombre=patrocinador.Nombre;
                     pat.tipoPersona=patrocinador.tipoPersona;
                     pat.Direccion=patrocinador.Direccion;
                     pat.Telefono=patrocinador.Telefono;
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
        
        bool IRepositorioPatrocinador.EliminarPatrocinador(int idPatrocinador)
        {
            bool eliminado=false;
            var Patrocinador = _appContext.Patrocinadores.Find(idPatrocinador);
            if (Patrocinador!=null)
            {
                try
                {
                     _appContext.Patrocinadores.Remove(Patrocinador);
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
        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            Patrocinador Patrocinador= _appContext.Patrocinadores.Find(idPatrocinador);
            return Patrocinador;
        }

        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _appContext.Patrocinadores;
        }

        bool Existe(Patrocinador patro)
        {
            bool ex=false;
            var pat=_appContext.Patrocinadores.FirstOrDefault(m=> m.Identificacion==patro.Identificacion);
            if(pat!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}