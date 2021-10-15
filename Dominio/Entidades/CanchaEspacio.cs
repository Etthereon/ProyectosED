using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class CanchaEspacio
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "No puede superar los 20 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "No puede superar los 20 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Solo se permiten letras.")]
        public string Disciplina { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "No puede superar los 20 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Solo se permiten letras.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, 200)]
        public int CapacidadEspectadores { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public double Medidas { get; set; }

        //llave foranea
        [Required(ErrorMessage = "El campo Escenario es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int EscenarioId { get; set; }

    }
}