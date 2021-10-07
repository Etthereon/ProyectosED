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
    public class EscIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEscenario _repoescenario;
        private readonly IRepositorioTorneo _repotorneo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Escenario> Escenarios {get;set;}
        public List<EscenarioView> EscenarioView = new List<EscenarioView>();
        public Escenario Escenario{get;set;}

        //Constructor
        public EscIndexModel(IRepositorioEscenario repoescenario, IRepositorioTorneo repotorneo)
        {
            this._repoescenario=repoescenario;
            this._repotorneo=repotorneo;
        }

        public void OnGet()
        {
            List<Torneo> ListTorneos = _repotorneo.ListarTorneos1();
            Escenarios = _repoescenario.ListarEscenarios();
            EscenarioView escView = null;
            foreach (var esc in Escenarios)
            {
                escView = new  EscenarioView();
                foreach (var tor in ListTorneos)
                {
                    if (esc.TorneoId==tor.id)
                    {
                        escView.Torneo=tor.Nombre;
                    } 
                }
                escView.id=esc.id;
                escView.Nombre=esc.Nombre;
                escView.Direccion=esc.Direccion;
                escView.Telefono=esc.Telefono;
                escView.Horario=esc.Horario;
                EscenarioView.Add(escView);
            }
        }
    }
}