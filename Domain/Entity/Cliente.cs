using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Cliente : Persona
    {
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

        public IEnumerable<Cuenta> Cuentas { get; set; }
    }
}
