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
        private readonly IRepositorioEquipo _repoequipo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Entrenador> Entrenadores {get;set;}
        public List<EntrenadorView> EntrenadorView= new List<EntrenadorView>(); 
        public Equipo Equipo {get;set;}

        //Constructor
        public EntIndexModel(IRepositorioEntrenador repoentrenador, IRepositorioEquipo repoequipo)
        {
            this._repoentrenador=repoentrenador;
            this._repoequipo=repoequipo;
        }

        public void OnGet()
        {
            List<Equipo> ListEquipos=_repoequipo.ListarEquipos1();
            Entrenadores = _repoentrenador.ListarEntrenadores();
            EntrenadorView EntView= null;
            foreach (var ent in Entrenadores)
            {
                EntView =new EntrenadorView();
                foreach(var equi in ListEquipos)
                {
                    if(ent.EquipoId==equi.id)
                    {
                        EntView.Equipo=equi.Nombre;
                    }
                }
                EntView.id=ent.id;
                EntView.Documento=ent.Documento;
                EntView.Nombres=ent.Nombres;
                EntView.Apellidos=ent.Apellidos;
                EntView.Genero =ent.Genero ;
                EntView.DisciplinaDeportiva=ent.DisciplinaDeportiva;
                EntrenadorView.Add(EntView);
            } 
        }
    }
}