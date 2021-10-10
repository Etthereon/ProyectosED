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
    public class CreateCEModel : PageModel
    {
         //Objeto para crear el repositorio
        private readonly IRepositorioCanchaEspacio _repocanchaespacio;
        private readonly IRepositorioEscenario _repoescenario;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public CanchaEspacio CanchaEspacio {get;set;}
        public IEnumerable<Escenario> Escenarios{get;set;}

        //Constructor
        public CreateCEModel(IRepositorioCanchaEspacio repocanchaespacio, IRepositorioEscenario repoescenario)
        {
            this._repocanchaespacio=repocanchaespacio;
            this._repoescenario=repoescenario;
        }
        
        public ActionResult OnGet()
        {
            Escenarios=_repoescenario.ListarEscenarios();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado =_repocanchaespacio.CrearCanchaEspacio(CanchaEspacio);
            if(creado)
            {
                return RedirectToPage("./CEIndex");
            }
            else
            {
                Escenarios=_repoescenario.ListarEscenarios();
                ViewData ["Mensaje"]= "La cancha espacio ya se encuentra registrada";
                return Page();
            }
        }
    }
}
