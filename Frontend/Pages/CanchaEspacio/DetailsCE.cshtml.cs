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
    public class DetailsCEModel : PageModel
    {
        private readonly IRepositorioCanchaEspacio _repocanchaespacio;
        private readonly IRepositorioEscenario _repoescenario;

        public DetailsCEModel(IRepositorioCanchaEspacio repocanchaespacio, IRepositorioEscenario repoescenario)
        {
            this._repocanchaespacio=repocanchaespacio;
            this._repoescenario=repoescenario;
        }
        [BindProperty]
        public CanchaEspacio CanchaEspacio{get;set;}
        public IEnumerable<Escenario> Escenarios{get;set;}

        public ActionResult OnGet(int id)
        {
            CanchaEspacio= _repocanchaespacio.BuscarCanchaEspacio(id);
            if (CanchaEspacio==null)
            {
                return NotFound();
            }
            Escenarios=_repoescenario.ListarEscenarios();
            return Page();
        }
    }
}
