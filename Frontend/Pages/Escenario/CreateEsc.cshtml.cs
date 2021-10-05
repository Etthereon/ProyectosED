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
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Escenario Escenario {get;set;}

        //Constructor
        public CreateEscModel(IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }
        
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado =_repoescenario.CrearEscenario(Escenario);
            if(creado)
            {
                return RedirectToPage("./EscIndex");
            }
            else
            {
                ViewData ["Mensaje"]= "El escenario ya se encuentra registrado";
                return Page();
            }
        }
    }
}
