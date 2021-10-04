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
    public class EquIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEquipo _repoequipo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Equipo> Equipos {get;set;}

        //Constructor
        public EquIndexModel(IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }

        public void OnGet()
        {
            Equipos = _repoequipo.ListarEquipos();
        }
    }
}