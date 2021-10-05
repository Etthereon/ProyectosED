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
    public class EditEscModel : PageModel
    {
        private readonly IRepositorioEscenario _repoescenario;
        public EditEscModel(IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}

        public ActionResult OnGet(int id)
        {            
            Escenario= _repoescenario.BuscarEscenario(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoescenario.ActualizarEscenario(Escenario);
            if(funciono)
            {
                return RedirectToPage("./EscIndex");
            }
            else
            {
                ViewData["Mensaje"]="Se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}