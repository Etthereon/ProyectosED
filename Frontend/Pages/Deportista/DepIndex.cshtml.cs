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
        private readonly IRepositorioEquipo _repoequipo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Deportista> Deportistas {get;set;}
        public List<DeportistaView> DeportistaView= new List<DeportistaView>(); 
        public Equipo Equipo {get;set;}

        //Constructor
        public DepIndexModel(IRepositorioDeportista repodeportista, IRepositorioEquipo repoequipo)
        {
            this._repodeportista=repodeportista;
            this._repoequipo=repoequipo;
        }

        public void OnGet()
        {
            List<Equipo> ListEquipos=_repoequipo.ListarEquipos1();
            Deportistas = _repodeportista.ListarDeportistas();
            DeportistaView DepV= null;
            foreach (var dep in Deportistas)
            {
                DepV =new DeportistaView();
                foreach(var equi in ListEquipos)
                {
                    if(dep.EquipoId==equi.id)
                    {
                        DepV.Equipo=equi.Nombre;
                    }
                }
                DepV.id=dep.id;
                DepV.Documento=dep.Documento;
                DepV.Nombres=dep.Nombres;
                DepV.Apellidos=dep.Apellidos;
                DepV.Genero =dep.Genero ;
                DepV.Rh=dep.Rh;
                DepV.EPS=dep.EPS;
                DepV.FechaNac=dep.FechaNac;
                DepV.Disciplina=dep.Disciplina;
                DepV.Direccion=dep.Direccion;
                DepV.NumeroEmergencia=dep.NumeroEmergencia;
                DeportistaView.Add(DepV);
            } 
        }
    }
}