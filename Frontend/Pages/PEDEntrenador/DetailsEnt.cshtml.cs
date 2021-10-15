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
    public class DetailsEntModel : PageModel
    {
        private readonly IRepositorioEntrenador _repoentrenador;
        private readonly IRepositorioEquipo _repoequipo;

        public DetailsEntModel(IRepositorioEntrenador repoentrenador, IRepositorioEquipo repoequipo)
        {
            this._repoentrenador=repoentrenador;
            this._repoequipo=repoequipo;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}
        public IEnumerable<Equipo> Equipo {get;set;}

        public ActionResult OnGet(int id)
        {
            Entrenador= _repoentrenador.BuscarEntrenador(id);
            Equipo= _repoequipo.ListarEquipos();
            if (Entrenador==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

