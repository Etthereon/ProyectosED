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
    public class EAIndexModel : PageModel
    {
        //Se llaman los repositorios. Crear objeto uso repositorios.
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;
        //Modelo u objeto para transportar hacia MIndex.cshtml.
        public IEnumerable <EscuelaArbitro> EscuelaArbitros {get;set;}
        //Constructor.
        public EAIndexModel (IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoescuelaarbitro=repoescuelaarbitro;
        }
        public void OnGet() //Entrega algo al usuario, es decir oprime una pestana y el programa muestra algo. 
        {
           EscuelaArbitros=_repoescuelaarbitro.ListarEscuelaArbitros();
        }
    }
}

