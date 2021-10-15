using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Arbitro
    {
        public int id {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(12,ErrorMessage="No puede superar los 12 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[0-9]*",ErrorMessage="Solo se permiten numeros, sin puntaciones.")]
        public string Documento{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Nombres{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Apellidos{get;set;}

        [MaxLength(15,ErrorMessage="No puede superar los 15 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Genero{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(25,ErrorMessage="No puede superar los 25 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Disciplina{get;set;}
        
        //llaves foraneas

        [Required(ErrorMessage = "El campo Torneo es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int TorneoId{get;set;}

        [Required(ErrorMessage = "El campo Escuela del Arbitro es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int EscuelaArbitroId{get;set;}

    }
}