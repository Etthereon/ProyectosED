using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Municipio
    {
        public int id {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(30,ErrorMessage="No puede superar los 30 caracteres.")]
        [MinLength(2,ErrorMessage="No puede ser menor de los 2 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Nombre{get;set;}
        //propiedad navigacional con Torneo
        public List<Torneo> Torneos{get;set;}
    }
}
