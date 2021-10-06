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
    public class CreateTorModel : PageModel
    {
        //Objeto para crear el repositorio
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioMunicipio _repomunicipio;
        //Propiedad para transportar al cshtml
        [BindProperty]
        public Torneo Torneo {get;set;}
        public IEnumerable<Municipio> Municipios{get;set;}

        //Constructor
        public CreateTorModel(IRepositorioTorneo repotorneo, IRepositorioMunicipio repomunicipio)
        {
            this._repotorneo=repotorneo;
            this._repomunicipio=repomunicipio;
        }
        
        public ActionResult OnGet()
        {
            Municipios=_repomunicipio.ListarMunicipios();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado =_repotorneo.CrearTorneo(Torneo);
            if(creado)
            {
                return RedirectToPage("./TorIndex");
            }
            else
            {
                Municipios=_repomunicipio.ListarMunicipios();
                ViewData ["Error"]= "El torneo ya se encuentra registrado";
                return Page();
            }
        }
    }
}

