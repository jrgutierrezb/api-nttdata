using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Cuenta> Cuentas { get; set; }
        DbSet<Movimiento> Movimientos { get; set; }
        Task<int> SaveChangesAsync();
    }
}
