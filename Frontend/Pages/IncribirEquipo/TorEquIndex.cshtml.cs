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
    public class TorEquIndexModel : PageModel
    {
         //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioTorneoEquipo _repotorneoequipo;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEquipo _repoequipo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<TorneoEquipo> TorneoEquipos {get;set;}
        public List<TorneoEquipoView> TorneoEquipoView = new List<TorneoEquipoView>();
        //public Torneo Torneo{get;set;}

        //Constructor
        public TorEquIndexModel(IRepositorioTorneoEquipo repotorneoequipo, IRepositorioTorneo repotorneo, IRepositorioEquipo repoequipo)
        {
            this._repotorneoequipo=repotorneoequipo;
            this._repotorneo=repotorneo;
            this._repoequipo=repoequipo;
        }

        public void OnGet()
        {
            List<Torneo> ListTorneos = _repotorneo.ListarTorneos1();
            List<Equipo> ListEquipos = _repoequipo.ListarEquipos1();
            TorneoEquipos = _repotorneoequipo.ListarTorneoEquipos();
            TorneoEquipoView torequView = null;
            foreach (var te in TorneoEquipos)
            {
                torequView = new  TorneoEquipoView();
                foreach (var tor in ListTorneos)
                {
                    if (te.TorneoId==tor.id)
                    {
                        torequView.Torneo=tor.Nombre;
                    } 
                }

                foreach(var equ in ListEquipos)
                {
                    if(te.EquipoId==equ.id)
                    {
                        torequView.Equipo= equ.Nombre;
                    }
                }
                TorneoEquipoView.Add(torequView);
            }
        }
    }
}