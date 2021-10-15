using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace Frontend.Pages
{
    public class EditEscuelaArbitroModel : PageModel
    {
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;

        public EditEscuelaArbitroModel(IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoescuelaarbitro = repoescuelaarbitro;
        }

        [BindProperty]
        public EscuelaArbitro EscuelaArbitro { get; set; }

        public ActionResult OnGet(int Id)
        {
            EscuelaArbitro = _repoescuelaarbitro.BuscarEscuelaArbitro(Id);
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool funciono = _repoescuelaarbitro.ActualizarEscuelaArbitro(EscuelaArbitro);
            if (funciono)
            {
                return RedirectToPage("./EAIndex");
            }
            else
            {
                ViewData["Mensaje"] = "se ha presentado un error...";
                return Page();
            }
        }
    }
}
