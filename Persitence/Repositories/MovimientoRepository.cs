using Application.Interfaces;
using Domain.Entity;
using Persitence.Context;

namespace Persitence.Repositories
{
    public class MovimientoRepository : Repository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
