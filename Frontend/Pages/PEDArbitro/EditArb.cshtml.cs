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
    public class EditArbModel : PageModel
    {
        private readonly IRepositorioArbitro _repoarbitro;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;

        public EditArbModel(IRepositorioArbitro repoarbitro, IRepositorioTorneo repotorneo, IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoarbitro = repoarbitro;
            this._repotorneo = repotorneo;
            this._repoescuelaarbitro = repoescuelaarbitro;
        }
        [BindProperty]
        public Arbitro Arbitro { get; set; }
        public IEnumerable<Torneo> Torneo { get; set; }
        public IEnumerable<EscuelaArbitro> EscuelaArbitro { get; set; }

        public ActionResult OnGet(int id)
        {
            Arbitro = _repoarbitro.BuscarArbitro(id);
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

            bool funciono = _repoarbitro.ActualizarArbitro(Arbitro);
            if (funciono)
            {
                return RedirectToPage("./ArbIndex");
            }
            else
            {
                Torneo = _repotorneo.ListarTorneos();
                EscuelaArbitro = _repoescuelaarbitro.ListarEscuelaArbitros();
                ViewData["Mensaje"] = "Se ha presentado un error...";
                return Page();
            }

        }
    }
}
