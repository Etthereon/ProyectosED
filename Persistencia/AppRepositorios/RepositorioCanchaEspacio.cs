using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioCanchaEspacio:IRepositorioCanchaEspacio
    {
        private readonly AppContext _appContext;

        public RepositorioCanchaEspacio(AppContext appContext)
        {
            _appContext=appContext;
        }

        // implementar de IRepositorio
        bool IRepositorioCanchaEspacio.CrearCanchaEspacio(CanchaEspacio canchaEspacio)
        {
            bool creado=false;
            bool ex= Existe(canchaEspacio);
            if(!ex)
            {
                try
                {
                    _appContext.CanchaEspacios.Add(canchaEspacio);
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

        bool IRepositorioCanchaEspacio.ActualizarCanchaEspacio(CanchaEspacio canchaEspacio)
        {
            bool actualizado=false;
            var canchaEsp=_appContext.CanchaEspacios.Find(canchaEspacio.id);
            if (canchaEsp!=null)
            {
                try
                {
                     canchaEsp.Nombre=canchaEspacio.Nombre;
                     canchaEsp.Disciplina=canchaEspacio.Disciplina;
                     canchaEsp.Estado=canchaEspacio.Estado;
                     canchaEsp.CapacidadEspectadores=canchaEspacio.CapacidadEspectadores;
                     canchaEsp.Medidas=canchaEspacio.Medidas;
                     canchaEsp.EscenarioId=canchaEspacio.EscenarioId;
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
        
        bool IRepositorioCanchaEspacio.EliminarCanchaEspacio(int idCanchaEspacio)
        {
            bool eliminado=false;
            var CanchaEspacio = _appContext.CanchaEspacios.Find(idCanchaEspacio);
            if (CanchaEspacio!=null)
            {
                try
                {
                     _appContext.CanchaEspacios.Remove(CanchaEspacio);
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
        CanchaEspacio IRepositorioCanchaEspacio.BuscarCanchaEspacio(int idCanchaEspacio)
        {
            CanchaEspacio canchaEspacio= _appContext.CanchaEspacios.Find(idCanchaEspacio);
            return canchaEspacio;
        }

        IEnumerable<CanchaEspacio> IRepositorioCanchaEspacio.ListarCanchaEspacios()
        {
            return _appContext.CanchaEspacios;
        }

        List<CanchaEspacio> IRepositorioCanchaEspacio.ListarCanchaEspacios1()
        {
            return _appContext.CanchaEspacios.ToList();
        }

        bool Existe(CanchaEspacio canc)
        {
            bool ex=false;
            var can=_appContext.CanchaEspacios.FirstOrDefault(c=> c.Nombre==canc.Nombre);
            if(can!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}