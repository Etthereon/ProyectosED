using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace Frontend.Pages
{
    public class DeleteEscuelaArbitroModel : PageModel
    {
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;
        
        public DeleteEscuelaArbitroModel(IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoescuelaarbitro=repoescuelaarbitro;
        }

        [BindProperty]
        public EscuelaArbitro EscuelaArbitro {get;set;}

        public ActionResult OnGet(int Id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            EscuelaArbitro= _repoescuelaarbitro.BuscarEscuelaArbitro(Id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoescuelaarbitro.EliminarEscuelaArbitro(EscuelaArbitro.id);
             if(funciono)
             {
                return RedirectToPage("./EAIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}