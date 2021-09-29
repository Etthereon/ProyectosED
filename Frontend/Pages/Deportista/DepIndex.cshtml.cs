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
    public class DepIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioDeportista _repodeportista;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Deportista> Deportistas {get;set;}

        //Constructor
        public DepIndexModel(IRepositorioDeportista repodeportista)
        {
            this._repodeportista=repodeportista;
        }

        public void OnGet()
        {
            Deportistas = _repodeportista.ListarDeportistas();
        }
    }
}