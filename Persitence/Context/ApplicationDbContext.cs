using Microsoft.EntityFrameworkCore;
using System;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Persitence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>().Property(p => p.SaldoInicial).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<Movimiento>().Property(p => p.Saldo).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<Movimiento>().Property(p => p.Valor).HasColumnType("decimal(10, 2)");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
