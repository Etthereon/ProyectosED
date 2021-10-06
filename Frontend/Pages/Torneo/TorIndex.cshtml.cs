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
    public class TorIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioTorneo _repotorneo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Torneo> Torneos {get;set;}

        //Constructor
        public TorIndexModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo=repotorneo;
        }

        public void OnGet()
        {
            Torneos = _repotorneo.ListarTorneos();
        }
    }
}
