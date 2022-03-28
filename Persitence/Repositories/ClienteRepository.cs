using Application.Interfaces;
using Domain.Entity;
using Persitence.Context;

namespace Persitence.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
