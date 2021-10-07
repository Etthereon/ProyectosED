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
    public class EditTorModel : PageModel
    {
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioMunicipio _repomunicipio;
        public EditTorModel(IRepositorioTorneo repotorneo, IRepositorioMunicipio repomunicipio)
        {
            this._repotorneo=repotorneo;
            this._repomunicipio=repomunicipio;
        }
        [BindProperty]
        public Torneo Torneo{get;set;}
        public IEnumerable<Municipio> Municipios{get;set;}

        public ActionResult OnGet(int id)
        {            
            Torneo= _repotorneo.BuscarTorneo(id);
            Municipios=_repomunicipio.ListarMunicipios();
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repotorneo.ActualizarTorneo(Torneo);
            if(funciono)
            {
                return RedirectToPage("./TorIndex");
            }
            else
            {
                Municipios=_repomunicipio.ListarMunicipios();
                ViewData["Mensaje"]="Se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}