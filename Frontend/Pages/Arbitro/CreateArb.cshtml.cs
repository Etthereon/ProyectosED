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
    public class CreateArbModel : PageModel
    {
        //Objeto para crear el repositorio
        private readonly IRepositorioArbitro _repoarbitro;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;

        //Propiedad para transportar al cshtml
        [BindProperty]
        public Arbitro Arbitro { get; set; }
        public IEnumerable<Torneo> Torneo { get; set; }
        public IEnumerable<EscuelaArbitro> EscuelaArbitro { get; set; }

        //Constructor
        public CreateArbModel(IRepositorioArbitro repoarbitro, IRepositorioTorneo repotorneo, IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoarbitro = repoarbitro;
            this._repotorneo = repotorneo;
            this._repoescuelaarbitro = repoescuelaarbitro;
        }

        public ActionResult OnGet()
        {
            Torneo = _repotorneo.ListarTorneos();
            EscuelaArbitro = _repoescuelaarbitro.ListarEscuelaArbitros();
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool creado = _repoarbitro.CrearArbitro(Arbitro);
            if (creado)
            {
                return RedirectToPage("./ArbIndex");
            }
            else
            {
                Torneo = _repotorneo.ListarTorneos();
                EscuelaArbitro = _repoescuelaarbitro.ListarEscuelaArbitros();
                ViewData["Mensaje"] = "El arbitro ya se encuentra registrado";
                return Page();
            }
        }
    }
}