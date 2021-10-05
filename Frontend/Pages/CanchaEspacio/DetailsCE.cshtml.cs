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
        public DetailsCEModel(IRepositorioCanchaEspacio repocanchaespacio)
        {
            this._repocanchaespacio=repocanchaespacio;
        }
        [BindProperty]
        public CanchaEspacio CanchaEspacio{get;set;}

        public ActionResult OnGet(int id)
        {
            CanchaEspacio= _repocanchaespacio.BuscarCanchaEspacio(id);
            if (CanchaEspacio==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
