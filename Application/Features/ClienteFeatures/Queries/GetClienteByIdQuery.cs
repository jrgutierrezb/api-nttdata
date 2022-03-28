using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public long Id { get; set; }
        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
        {
            private readonly IApplicationDbContext _context;
            public GetClienteByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Cliente> Handle(GetClienteByIdQuery query, CancellationToken cancellationToken)
            {
                var cliente = _context.Clientes.FirstOrDefault(a => a.Id == query.Id);
                if (cliente == null) return null;
                return cliente;
            }
        }
        
    }
}
