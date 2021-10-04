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
    public class CreateEquModel : PageModel
    {
        //Objeto para crear el repositorio
        private readonly IRepositorioEquipo _repoequipo;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Equipo Equipo {get;set;}

        //Constructor
        public CreateEquModel(IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }
        
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado =_repoequipo.CrearEquipo(Equipo);
            if(creado)
            {
                return RedirectToPage("./EquIndex");
            }
            else
            {
                ViewData ["Mensaje"]= "El equipo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
