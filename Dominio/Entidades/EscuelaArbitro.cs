using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class EscuelaArbitro
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "No puede superar los 30 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(12, ErrorMessage = "No puede superar los 12 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Resolucion { get; set; }

        [MaxLength(30, ErrorMessage = "No puede superar los 30 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Direccion { get; set; }

        [MaxLength(15, ErrorMessage = "No puede superar los 15 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[0-9]*", ErrorMessage = "Solo se permiten numeros.")]
        public string Telefono { get; set; }

        [MaxLength(30, ErrorMessage = "No puede superar los 30 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Correo { get; set; }

        //pripiedad navigacional
        public List<Arbitro> Arbitros { get; set; }
    }
}