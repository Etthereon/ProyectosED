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
    public class EntIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEntrenador _repoentrenador;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Entrenador> Entrenadores {get;set;}

        //Constructor
        public EntIndexModel(IRepositorioEntrenador repoentrenador)
        {
            this._repoentrenador=repoentrenador;
        }

        public void OnGet()
        {
            Entrenadores = _repoentrenador.ListarEntrenadores();
        }
    }
}