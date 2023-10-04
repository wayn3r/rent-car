﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Tanda es obligatorio.")]
        public string NoTarjetaCR { get; set; }

        [Required(ErrorMessage = "El campo porcentaje de comision es obligatorio.")]
        public decimal LimiteCredito { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Ingreso es obligatorio.")]
        public string TipoPersona { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; }
    }
}
