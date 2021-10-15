using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    public class Entrenador
    {
        public int id {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(12,ErrorMessage="No puede superar los 12 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[0-9]*",ErrorMessage="Solo se permiten numeros, sin puntaciones.")]
        public string Documento{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 5 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Nombres{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 5 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Apellidos{get;set;}

        [MaxLength(15,ErrorMessage="No puede superar los 15 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 5 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Genero{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(20,ErrorMessage="No puede superar los 20 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 5 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string DisciplinaDeportiva{get;set;}

        //llaves foraneas
        [Required(ErrorMessage = "El campo Equipo es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int EquipoId{get;set;}
    }
}