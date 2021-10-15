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
    public class CreateEscModel : PageModel
    {
        //Objeto para crear el repositorio
        private readonly IRepositorioEscenario _repoescenario;
        private readonly IRepositorioTorneo _repotorneo;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Escenario Escenario { get; set; }
        public IEnumerable<Torneo> Torneos { get; set; }

        //Constructor
        public CreateEscModel(IRepositorioEscenario repoescenario, IRepositorioTorneo repotorneo)
        {
            this._repoescenario = repoescenario;
            this._repotorneo = repotorneo;
        }

        public ActionResult OnGet()
        {
            Torneos = _repotorneo.ListarTorneos();
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool creado = _repoescenario.CrearEscenario(Escenario);
            if (creado)
            {
                return RedirectToPage("./EscIndex");
            }
            else
            {
                Torneos = _repotorneo.ListarTorneos();
                ViewData["Error"] = "El escenario ya se encuentra registrado";
                return Page();
            }
        }
    }
}
