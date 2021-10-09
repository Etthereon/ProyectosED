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
        private readonly IRepositorioPatrocinador _repopatrocinador;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Equipo> Equipos {get;set;}
        public List<EquipoView> EquipoView= new List<EquipoView>(); 
        public Patrocinador Patrocinador {get;set;}

        //Constructor
        public EquIndexModel(IRepositorioEquipo repoequipo, IRepositorioPatrocinador repopatrocinador)
        {
            this._repoequipo=repoequipo;
            this._repopatrocinador=repopatrocinador;
        }

        public void OnGet()
        {
            List<Patrocinador> ListPatrocinadores=_repopatrocinador.ListarPatrocinadores1();
            Equipos = _repoequipo.ListarEquipos();
            EquipoView EV= null;
            foreach (var Equi in Equipos)
            {
                EV =new EquipoView();
                foreach(var pat in ListPatrocinadores)
                {
                    if(Equi.PatrocinadorId==pat.id)
                    {
                        EV.Patrocinador=pat.Nombre;
                    }
                }
                EV.id=Equi.id;
                EV.Nombre=Equi.Nombre;
                EV.CantidadDeportistas=Equi.CantidadDeportistas;
                EV.Disciplina=Equi.Disciplina;
                EquipoView.Add(EV);
            }
        }
    }
}