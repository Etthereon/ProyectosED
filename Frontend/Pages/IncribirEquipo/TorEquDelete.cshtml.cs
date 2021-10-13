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
    public class TorEquDeleteModel : PageModel
    {
        private readonly IRepositorioTorneoEquipo _repotorneoequipo;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEquipo _repoequipo;

        public TorEquDeleteModel(IRepositorioTorneoEquipo repotorneoequipo, IRepositorioTorneo repotorneo, IRepositorioEquipo repoequipo)
        {
            this._repotorneoequipo=repotorneoequipo;
            this._repotorneo=repotorneo;
            this._repoequipo=repoequipo;
        }

        [BindProperty]
        public TorneoEquipo TorneoEquipo {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}

        public ActionResult OnGet(int TorneoId, int EquipoId)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            TorneoEquipo= _repotorneoequipo.BuscarTorneoEquipo(TorneoId, EquipoId);
            Torneos=_repotorneo.ListarTorneos();
            Equipos=_repoequipo.ListarEquipos();
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repotorneoequipo.EliminarTorneoEquipo(TorneoEquipo.TorneoId, TorneoEquipo.EquipoId);
             if(funciono)
             {
                return RedirectToPage("./TorEquIndex");
             }
             else
             {
                Torneos=_repotorneo.ListarTorneos();
                Equipos=_repoequipo.ListarEquipos();
                return Page();
             }
             
         }
    }
}