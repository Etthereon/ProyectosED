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
        private readonly IRepositorioPatrocinador _repopatrocinador;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Equipo Equipo {get;set;}
        public IEnumerable<Patrocinador> Patrocinador{get;set;} 

        //Constructor
        public CreateEquModel(IRepositorioEquipo repoequipo, IRepositorioPatrocinador repopatrocinador)
        {
            this._repoequipo=repoequipo;
            this._repopatrocinador=repopatrocinador;
        }
        
        public ActionResult OnGet()
        {
            Patrocinador=_repopatrocinador.ListarPatrocinadores();
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
                Patrocinador=_repopatrocinador.ListarPatrocinadores();
                ViewData ["Mensaje"]= "El equipo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
