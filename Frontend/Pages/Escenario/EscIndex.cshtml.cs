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
    public class EscIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEscenario _repoescenario;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Escenario> Escenarios {get;set;}

        //Constructor
        public EscIndexModel(IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }

        public void OnGet()
        {
            Escenarios = _repoescenario.ListarEscenarios();
        }
    }
}
