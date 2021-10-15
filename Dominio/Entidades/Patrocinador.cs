using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Patrocinador
    {
        public int id {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(15,ErrorMessage="No puede superar los 15 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[0-9]*",ErrorMessage="Solo se permiten numeros.")] 
        public string Identificacion{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(25,ErrorMessage="No puede superar los 25 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string Nombre{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MaxLength(15,ErrorMessage="No puede superar los 15 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*",ErrorMessage="Solo se permiten letras.")]
        public string tipoPersona{get;set;}

        [MaxLength(30,ErrorMessage="No puede superar los 30 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        public string Direccion{get;set;}

        [MaxLength(15,ErrorMessage="No puede superar los 15 caracteres.")]
        [MinLength(3,ErrorMessage="No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[0-9]*",ErrorMessage="Solo se permiten numeros.")] 
        public string Telefono{get;set;}

        //pripiedad navigacional
        public List<Equipo> Equipos{get;set;}
    }
}