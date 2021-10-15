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
    public class EditPatrocinadorModel : PageModel
    {
       private readonly IRepositorioPatrocinador _repopatrocinador;

        public EditPatrocinadorModel(IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador= repopatrocinador;
        }
        
        [BindProperty]
        public Patrocinador Patrocinador {get;set;}

        public ActionResult OnGet(int id)
        {            
            Patrocinador= _repopatrocinador.BuscarPatrocinador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             if(!ModelState.IsValid)
            {
                return Page();
            }
                       
            bool funciono=_repopatrocinador.ActualizarPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./PIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}

