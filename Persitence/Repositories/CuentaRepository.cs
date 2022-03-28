using Application.Interfaces;
using Domain.Entity;
using Persitence.Context;

namespace Persitence.Repositories
{
    public class CuentaRepository : Repository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
