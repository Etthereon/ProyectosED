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
    public class ArbIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioArbitro _repoarbitro;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEscuelaArbitro _repoescuelaarbitro;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Arbitro> Arbitros {get;set;}
        public List<ArbitroView> ArbitroView= new List<ArbitroView>(); 
        public Torneo Torneo {get;set;}
        public EscuelaArbitro EscuelaArbitro {get;set;}

        //Constructor
        public ArbIndexModel(IRepositorioArbitro repoarbitro, IRepositorioTorneo repotorneo, IRepositorioEscuelaArbitro repoescuelaarbitro)
        {
            this._repoarbitro=repoarbitro;
            this._repotorneo=repotorneo;
            this._repoescuelaarbitro=repoescuelaarbitro;
        }

        public void OnGet()
        {
            List<Torneo> ListTorneos=_repotorneo.ListarTorneos1();
            List <EscuelaArbitro> ListEscuelaArbitros= _repoescuelaarbitro.ListarEscuelaArbitros1();
            Arbitros = _repoarbitro.ListarArbitros();
            ArbitroView ArbView= null;
            foreach (var arb in Arbitros)
             {
                ArbView =new ArbitroView();
                foreach(var tor in ListTorneos)
                {
                    if(arb.TorneoId==tor.id)
                    {
                       ArbView.Torneo=tor.Nombre;
                    }
                }
                 foreach(var escarb in ListEscuelaArbitros)
                  {
                       if(arb.EscuelaArbitroId==escarb.id)
                        {
                             ArbView.EscuelaArbitro=escarb.Nombre;
                        }
                  }
                ArbView.id=arb.id;
                ArbView.Documento=arb.Documento;
                ArbView.Nombres=arb.Nombres;
                ArbView.Apellidos=arb.Apellidos;
                ArbView.Genero =arb.Genero ;
                ArbView.Disciplina=arb.Disciplina;;
                ArbitroView.Add(ArbView);
             }
        }
    }
}
