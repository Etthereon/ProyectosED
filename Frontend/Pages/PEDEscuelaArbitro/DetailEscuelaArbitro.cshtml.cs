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
    public class DetailEscuelaArbitroModel : PageModel
     {
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;

        public DetailEscuelaArbitroModel(IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoescuelaarbitro=repoescuelaarbitro;
        }
        [BindProperty]
        public EscuelaArbitro EscuelaArbitro {get;set;}

        public ActionResult OnGet(int Id)
        {
            EscuelaArbitro= _repoescuelaarbitro.BuscarEscuelaArbitro(Id);
            if (EscuelaArbitro==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

