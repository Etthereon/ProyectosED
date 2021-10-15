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
    public class CreatePatrocinadorModel : PageModel
    {
        //Crear un objeto para utilizar el repositorio.
        private readonly IRepositorioPatrocinador _repopatrocinador;
        //Crear propiedad para trasportar al cshtml
        [BindProperty] //Se tiene que crear un uso directo y se debe etiquetar, se hace asi, Como propiedad principal.
        public Patrocinador Patrocinador {get;set;}
        //Constructor 
        public CreatePatrocinadorModel (IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }
        //Retornar usuario. 
        public ActionResult OnGet() //retornar algo al usuario, no puede ser void, por ese se pone un ActionResult.
        {
            return Page(); //Si no se especifica retorna la pagina asociada. 
        }
        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
           bool creado= _repopatrocinador.CrearPatrocinador(Patrocinador);
           if (creado)
           {
               return RedirectToPage("./PIndex");
           }
           else 
           {
               ViewData["Mensaje"]= "El patrocinador ya se encuntra registrado"; //Identificador. 

               return Page();
           }
        }
    }
}
