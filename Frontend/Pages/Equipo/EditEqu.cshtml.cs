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
    public class EditEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoequipo;
        private readonly IRepositorioPatrocinador _repopatrocinador;

        public EditEquModel(IRepositorioEquipo repoequipo, IRepositorioPatrocinador repopatrocinador)
        {
            this._repoequipo = repoequipo;
            this._repopatrocinador = repopatrocinador;
        }
        [BindProperty]
        public Equipo Equipo { get; set; }
        public IEnumerable<Patrocinador> Patrocinador { get; set; }

        public ActionResult OnGet(int id)
        {
            Equipo = _repoequipo.BuscarEquipo(id);
            Patrocinador = _repopatrocinador.ListarPatrocinadores();
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool funciono = _repoequipo.ActualizarEquipo(Equipo);
            if (funciono)
            {
                return RedirectToPage("./EquIndex");
            }
            else
            {
                Patrocinador = _repopatrocinador.ListarPatrocinadores();
                ViewData["Mensaje"] = "Se ha presentado un error...";
                return Page();
            }

        }
    }
}
