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
    public class TorIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioMunicipio _repomunicipio;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Torneo> Torneos {get;set;}
        public List<TorneoView> TorneoView = new List<TorneoView>();
        public Municipio Municipio{get;set;}

        //Constructor
        public TorIndexModel(IRepositorioTorneo repotorneo, IRepositorioMunicipio repomunicipio)
        {
            this._repotorneo=repotorneo;
            this._repomunicipio=repomunicipio;
        }

        public void OnGet()
        {
            List<Municipio> ListMunicipios = _repomunicipio.ListarMunicipios1();
            Torneos = _repotorneo.ListarTorneos();
            TorneoView tv = null;
            foreach (var tor in Torneos)
            {
                tv = new  TorneoView();
                foreach (var mun in ListMunicipios)
                {
                    if (tor.MunicipioId==mun.id)
                    {
                        tv.Municipio=mun.Nombre;
                    } 
                }
                tv.id=tor.id;
                tv.Nombre=tor.Nombre;
                tv.Categoria=tor.Categoria;
                tv.FechaInicial=tor.FechaInicial;
                tv.FechaFinal=tor.FechaFinal;
                tv.Tipo=tor.Tipo;
                TorneoView.Add(tv);
            }
        }
    }
}
