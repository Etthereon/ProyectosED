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
    public class CreateEntModel : PageModel
    {
        //Objeto para crear el repositorio
        private readonly IRepositorioEntrenador _repoentrenador;
        private readonly IRepositorioEquipo _repoequipo;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Entrenador Entrenador { get; set; }
        public IEnumerable<Equipo> Equipo { get; set; }

        //Constructor
        public CreateEntModel(IRepositorioEntrenador repoentrenador, IRepositorioEquipo repoequipo)
        {
            this._repoentrenador = repoentrenador;
            this._repoequipo = repoequipo;
        }

        public ActionResult OnGet()
        {
            Equipo = _repoequipo.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool creado = _repoentrenador.CrearEntrenador(Entrenador);
            if (creado)
            {
                return RedirectToPage("./EntIndex");
            }
            else
            {
                Equipo = _repoequipo.ListarEquipos();
                ViewData["Mensaje"] = "El entrenador ya se encuentra registrado";
                return Page();
            }
        }
    }
}
