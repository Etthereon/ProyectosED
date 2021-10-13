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
    public class EditEntModel : PageModel
    {
       private readonly IRepositorioEntrenador _repoentrenador;
       private readonly IRepositorioEquipo _repoequipo;
       
        public EditEntModel(IRepositorioEntrenador repoentrenador, IRepositorioEquipo repoequipo)
        {
            this._repoentrenador=repoentrenador;
            this._repoequipo=repoequipo;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}
        public IEnumerable<Equipo> Equipo{get;set;} 
        

        public ActionResult OnGet(int id)
        {            
            Entrenador= _repoentrenador.BuscarEntrenador(id);
            Equipo=_repoequipo.ListarEquipos();
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoentrenador.ActualizarEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./EntIndex");
            }
            else
            {
                Equipo=_repoequipo.ListarEquipos();
                ViewData["Mensaje"]="Se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}