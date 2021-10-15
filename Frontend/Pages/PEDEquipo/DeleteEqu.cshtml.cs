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
    public class DeleteEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoequipo;
        private readonly IRepositorioPatrocinador _repopatrocinador;

        public DeleteEquModel(IRepositorioEquipo repoequipo, IRepositorioPatrocinador repopatrocinador)
        {
            this._repoequipo=repoequipo;
            this._repopatrocinador=repopatrocinador;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}
        public IEnumerable<Patrocinador> Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Equipo= _repoequipo.BuscarEquipo(id);
            Patrocinador=_repopatrocinador.ListarPatrocinadores();
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoequipo.EliminarEquipo(Equipo.id);
             if(funciono)
             {
                return RedirectToPage("./EquIndex");
             }
             else
             {
                 Patrocinador=_repopatrocinador.ListarPatrocinadores();
                 return Page();
             }
             
         }
    }
}

