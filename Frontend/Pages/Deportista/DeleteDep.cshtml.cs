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
    public class DeleteDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repodeportista;
        private readonly IRepositorioEquipo _repoequipo;

        public DeleteDepModel(IRepositorioDeportista repodeportista, IRepositorioEquipo repoequipo)
        {
            this._repodeportista=repodeportista;
            this._repoequipo=repoequipo;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}
        public IEnumerable<Equipo> Equipo{get;set;} 

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="¿Esta seguro de eliminar el registro?";
            Deportista= _repodeportista.BuscarDeportista(id);
            Equipo =_repoequipo.ListarEquipos();
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repodeportista.EliminarDeportista(Deportista.id);
             if(funciono)
             {
                return RedirectToPage("./DepIndex");
             }
             else
             {
                 Equipo =_repoequipo.ListarEquipos();
                 return Page();
             }
             
         }
    }
}