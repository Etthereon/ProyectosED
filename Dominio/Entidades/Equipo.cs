using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Equipo
    {
        public int id {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Nombre{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [Range(1,50)]
        public int CantidadDeportistas {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Disciplina{get;set;}

        //propiedad navigacional
        public Entrenador Entrenador {get;set;} //public Entrenador Entrenador {get;set;}
        public List<TorneoEquipo> TorneoEquipos{get;set;}
        public List<Deportista> Deportistas{get;set;}

        //llaves foraneas
        [Required(ErrorMessage = "El campo Patrocinador es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int PatrocinadorId {get;set;}
        
    }
}
