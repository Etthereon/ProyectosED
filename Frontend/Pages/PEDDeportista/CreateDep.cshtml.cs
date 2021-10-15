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
    public class CreateDepModel : PageModel
    {
        //Objeto para crear el repositorio
        private readonly IRepositorioDeportista _repodeportista;
        private readonly IRepositorioEquipo _repoequipo;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Deportista Deportista { get; set; }
        public IEnumerable<Equipo> Equipo { get; set; }

        //Constructor
        public CreateDepModel(IRepositorioDeportista repodeportista, IRepositorioEquipo repoequipo)
        {
            this._repodeportista = repodeportista;
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

            bool creado = _repodeportista.CrearDeportista(Deportista);
            if (creado)
            {
                return RedirectToPage("./DepIndex");
            }
            else
            {
                Equipo = _repoequipo.ListarEquipos();
                ViewData["Mensaje"] = "El deportista ya se encuentra registrado";
                return Page();
            }
        }
    }
}