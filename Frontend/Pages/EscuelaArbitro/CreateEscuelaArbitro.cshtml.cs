using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace Frontend.Pages
{
    public class CreateEscuelaArbitroModel : PageModel
    {
        //Crear un objeto para utilizar el repositorio.
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;
        //Crear propiedad para trasportar al cshtml
        [BindProperty] //Se tiene que crear un uso directo y se debe etiquetar, se hace asi, Como propiedad principal.
        public EscuelaArbitro EscuelaArbitro {get;set;}
        //Constructor 
        public CreateEscuelaArbitroModel (IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoescuelaarbitro=repoescuelaarbitro;
        }
        //Retornar usuario. 
        public ActionResult OnGet() //retornar algo al usuario, no puede ser void, por ese se pone un ActionResult.
        {
            return Page(); //Si no se especifica retorna la pagina asociada. 
        }
        public ActionResult OnPost()
        {
           bool creado= _repoescuelaarbitro.CrearEscuelaArbitro(EscuelaArbitro);
           if (creado)
           {
               return RedirectToPage("./EAIndex");
           }
           else 
           {
               ViewData["Mensaje"]= "La Escuela ya se encuntra registrada"; //Identificador. 

               return Page();
           }
        }
    }
}
