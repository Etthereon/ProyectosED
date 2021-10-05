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
    public class CEIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioCanchaEspacio _repocanchaespacio;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<CanchaEspacio> CanchaEspacios {get;set;}

        //Constructor
        public CEIndexModel(IRepositorioCanchaEspacio repocanchaespacio)
        {
            this._repocanchaespacio=repocanchaespacio;
        }

        public void OnGet()
        {
            CanchaEspacios = _repocanchaespacio.ListarCanchaEspacios();
        }
    }
}