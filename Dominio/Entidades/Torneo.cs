using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Torneo
    {
        public int id {get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4, ErrorMessage = "El campo {0} no puede tener menos de {1} caracteres")]
        public string Nombre{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4, ErrorMessage = "El campo {0} no puede tener menos de {1} caracteres")]
        public string Categoria{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicial{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaFinal{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4, ErrorMessage = "El campo {0} no puede tener menos de {1} caracteres")]
        public string Tipo{get;set;}

        //llaves foraneas
        [Required(ErrorMessage = "El campo Municipio es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int MunicipioId {get;set;}


        //propiedades navigacionales
        public List<TorneoEquipo> TorneosEquipos{get;set;}
        public List<Escenario> Escenarios{get;set;}
        public List<Arbitro> Arbitros{get;set;}


    }
}
