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
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Arbitro Arbitro {get;set;}

        //Constructor
        public CreateArbModel(IRepositorioArbitro repoarbitro)
        {
            this._repoarbitro=repoarbitro;
        }
        
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado =_repoarbitro.CrearArbitro(Arbitro);
            if(creado)
            {
                return RedirectToPage("./ArbIndex");
            }
            else
            {
                ViewData ["Mensaje"]= "El arbitro ya se encuentra registrado";
                return Page();
            }
        }
    }
}