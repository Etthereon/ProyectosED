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
    public class ArbIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioArbitro _repoarbitro;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Arbitro> Arbitros {get;set;}

        //Constructor
        public ArbIndexModel(IRepositorioArbitro repoarbitro)
        {
            this._repoarbitro=repoarbitro;
        }

        public void OnGet()
        {
            Arbitros = _repoarbitro.ListarArbitros();
        }
    }
}
