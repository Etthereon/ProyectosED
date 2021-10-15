using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Escenario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "No puede superar los 20 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(20, ErrorMessage = "No puede superar los 20 caracteres.")]
        [MinLength(3, ErrorMessage = "No puede ser menor de los 3 caracteres.")]
        public string Direccion { get; set; }

        [MaxLength(12, ErrorMessage = "No puede superar los 12 caracteres.")]
        [MinLength(5, ErrorMessage = "No puede ser menor de los 5 caracteres.")]
        [RegularExpression("[0-9]*", ErrorMessage = "Solo se permiten numeros, sin puntaciones.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "No puede superar los 20 caracteres.")]
        [MinLength(2, ErrorMessage = "No puede ser menor de los 5 caracteres.")]
        public string Horario { get; set; }

        //llaves foraneas
        [Required(ErrorMessage = "El campo Torneo es obligatorio, seleccione una opcion o vaya a la tabla y creela previamente")]
        public int TorneoId { get; set; }

        //pripiedad navigacional con Torneo
        public List<CanchaEspacio> CanchaEspacios { get; set; }
    }
}