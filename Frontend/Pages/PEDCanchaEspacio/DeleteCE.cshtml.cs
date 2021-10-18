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
       private readonly IRepositorioEscenario _repoescenario;

        public DeleteCEModel(IRepositorioCanchaEspacio repocanchaespacio, IRepositorioEscenario repoescenario)
        {
            this._repocanchaespacio=repocanchaespacio;
            this._repoescenario=repoescenario;
        }
        [BindProperty]
        public CanchaEspacio CanchaEspacio{get;set;}
        public IEnumerable<Escenario> Escenarios{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="¿Esta seguro de eliminar el registro?";
            CanchaEspacio= _repocanchaespacio.BuscarCanchaEspacio(id);
            Escenarios=_repoescenario.ListarEscenarios();
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
                 Escenarios=_repoescenario.ListarEscenarios();
                 return Page();
             }
             
         }
    }
}
