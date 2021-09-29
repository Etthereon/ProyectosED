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
    public class PIndexModel : PageModel
    {
        //Se llaman los repositorios. Crear objeto uso repositorios.
        private readonly IRepositorioPatrocinador _repopatrocinador;
        //Modelo u objeto para transportar hacia MIndex.cshtml.
        public IEnumerable <Patrocinador> Patrocinadores {get;set;}
        //Constructor.
        public PIndexModel (IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }
        public void OnGet() //Entrega algo al usuario, es decir oprime una pestana y el programa muestra algo. 
        {
           Patrocinadores=_repopatrocinador.ListarPatrocinadores();
        }
    }
}