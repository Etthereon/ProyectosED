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
    public class DeleteTorModel : PageModel
    {
        private readonly IRepositorioTorneo _repotorneo;
        public DeleteTorModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo=repotorneo;
        }
        [BindProperty]
        public Torneo Torneo{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Torneo= _repotorneo.BuscarTorneo(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repotorneo.EliminarTorneo(Torneo.id);
             if(funciono)
             {
                return RedirectToPage("./TorIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}