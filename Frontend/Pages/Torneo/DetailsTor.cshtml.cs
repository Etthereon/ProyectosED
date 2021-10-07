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
    public class DetailsTorModel : PageModel
    {
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioMunicipio _repomunicipio;
        public DetailsTorModel(IRepositorioTorneo repotorneo, IRepositorioMunicipio repomunicipio)
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
            if (Torneo==null)
            {
                return NotFound();
            }
            Municipios=_repomunicipio.ListarMunicipios();
            return Page();
        }
    }
}
