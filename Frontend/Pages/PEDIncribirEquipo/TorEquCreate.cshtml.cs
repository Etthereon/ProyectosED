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
    public class TorEquCreateModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioTorneoEquipo _repotorneoequipo;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEquipo _repoequipo;

        //Modelo u objeto para transportar hacia TorEquIndex.cshtml
        [BindProperty]
        public TorneoEquipo TorneoEquipo {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}
        //public Torneo Torneo{get;set;}

        //Constructor
        public TorEquCreateModel(IRepositorioTorneoEquipo repotorneoequipo, IRepositorioTorneo repotorneo, IRepositorioEquipo repoequipo)
        {
            this._repotorneoequipo=repotorneoequipo;
            this._repotorneo=repotorneo;
            this._repoequipo=repoequipo;
        }
        public ActionResult OnGet()
        {
            Torneos= _repotorneo.ListarTorneos();
            Equipos= _repoequipo.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado =_repotorneoequipo.CrearTorneoEquipo(TorneoEquipo);
            if(creado)
            {
                return RedirectToPage("./TorEquIndex");
            }
            else
            {
                Torneos=_repotorneo.ListarTorneos();
                Equipos=_repoequipo.ListarEquipos();
                ViewData ["Error"]= "El equipo ya se encuentra registrado en el torneo";
                return Page();
            }
        }
    }
}
