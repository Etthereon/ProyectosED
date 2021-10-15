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
    public class DeletePatrocinadorModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repopatrocinador;
        
        public DeletePatrocinadorModel(IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }

        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Patrocinador= _repopatrocinador.BuscarPatrocinador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repopatrocinador.EliminarPatrocinador(Patrocinador.id);
             if(funciono)
             {
                return RedirectToPage("./PIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}