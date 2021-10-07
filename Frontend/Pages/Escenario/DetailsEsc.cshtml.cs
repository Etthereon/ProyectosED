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
    public class DetailsEscModel : PageModel
    {
         private readonly IRepositorioEscenario _repoescenario;
         private readonly IRepositorioTorneo _repotorneo;
        public DetailsEscModel(IRepositorioEscenario repoescenario, IRepositorioTorneo repotorneo)
        {
            this._repoescenario=repoescenario;
            this._repotorneo=repotorneo;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}

        public ActionResult OnGet(int id)
        {
            Escenario= _repoescenario.BuscarEscenario(id);
            if (Escenario==null)
            {
                return NotFound();
            }
            Torneos=_repotorneo.ListarTorneos();
            return Page();
        }
    }
}

