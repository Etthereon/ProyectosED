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
    public class DeleteCEModel : PageModel
    {
       private readonly IRepositorioCanchaEspacio _repocanchaespacio;
        public DeleteCEModel(IRepositorioCanchaEspacio repocanchaespacio)
        {
            this._repocanchaespacio=repocanchaespacio;
        }
        [BindProperty]
        public CanchaEspacio CanchaEspacio{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            CanchaEspacio= _repocanchaespacio.BuscarCanchaEspacio(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repocanchaespacio.EliminarCanchaEspacio(CanchaEspacio.id);
             if(funciono)
             {
                return RedirectToPage("./CEIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
