using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Movimiento : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public TipoMovimientos TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }

        public enum TipoMovimientos
        {
            DEBITO,
            CREDITO
        }
    }
}
