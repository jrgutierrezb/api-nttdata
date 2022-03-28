using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Persona : BaseEntity
    {
        public string Nombre { get; set; }
        public Generos Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public enum Generos
        {
            MASCULINO,
            FEMENINO
        }
    }
}
