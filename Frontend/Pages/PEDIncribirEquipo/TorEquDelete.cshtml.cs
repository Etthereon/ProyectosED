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
        public Torneo Torneo {get;set;}
        public Equipo Equipo {get;set;}

        public ActionResult OnGet(int IdTor, int IdEqu)
        {
            
            TorneoEquipo= _repotorneoequipo.BuscarTorneoEquipo(IdTor, IdEqu);
            Torneo=_repotorneo.BuscarTorneo(IdTor);
            Equipo=_repoequipo.BuscarEquipo(IdEqu);
            if(TorneoEquipo!=null)
            {
                ViewData["Mensaje"]="¿Esta seguro de eliminar el equipo del torneo?";
                return Page();
            }
            else
            {
                return RedirectToPage("./TorEquIndex");
            }
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
                ViewData["Error"]="No es posible retirar el equipo del torneo";
                return Page();
             }
             
         }
    }
}