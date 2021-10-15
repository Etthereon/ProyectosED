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
    public class DeleteEscModel : PageModel
    {
        private readonly IRepositorioEscenario _repoescenario;
        private readonly IRepositorioTorneo _repotorneo;

        public DeleteEscModel(IRepositorioEscenario repoescenario, IRepositorioTorneo repotorneo )
        {
            this._repoescenario=repoescenario;
            this._repotorneo=repotorneo;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="¿Esta seguro de eliminar el registro?";
            Escenario= _repoescenario.BuscarEscenario(id);
            Torneos=_repotorneo.ListarTorneos();
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoescenario.EliminarEscenario(Escenario.id);
             if(funciono)
             {
                return RedirectToPage("./EscIndex");
             }
             else
             {
                 Torneos=_repotorneo.ListarTorneos();
                 return Page();
             }
             
         }
    }
}