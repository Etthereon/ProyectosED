using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class CEIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioCanchaEspacio _repocanchaespacio;
        private readonly IRepositorioEscenario _repoescenario;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<CanchaEspacio> CanchaEspacios {get;set;}
        public List<CanchaEspacioView> CanchaEspacioView = new List<CanchaEspacioView>();
        public Escenario Escenario{get;set;}

        //Constructor
        public CEIndexModel(IRepositorioCanchaEspacio repocanchaespacio, IRepositorioEscenario repoescenario)
        {
            this._repocanchaespacio=repocanchaespacio;
            this._repoescenario=repoescenario;
        }

        public void OnGet()
        {
            List<Escenario> ListEscenarios = _repoescenario.ListarEscenarios1();
            CanchaEspacios = _repocanchaespacio.ListarCanchaEspacios();
            CanchaEspacioView CEView = null;
            foreach (var canesp in CanchaEspacios)
            {
                CEView = new  CanchaEspacioView();
                foreach (var esc in ListEscenarios)
                {
                    if (canesp.EscenarioId==esc.id)
                    {
                        CEView.Escenario=esc.Nombre;
                    } 
                }
                CEView.id=canesp.id;
                CEView.Nombre=canesp.Nombre;
                CEView.Disciplina=canesp.Disciplina;
                CEView.Estado=canesp.Estado;
                CEView.CapacidadEspectadores=canesp.CapacidadEspectadores;
                CEView.Medidas=canesp.Medidas;
                CanchaEspacioView.Add(CEView);
            }
        }
    }
}