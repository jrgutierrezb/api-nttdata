using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetAllClientesQuery : IRequest<IEnumerable<Cliente>>
    {
        public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<Cliente>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllClientesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Cliente>> Handle(GetAllClientesQuery query, CancellationToken cancellationToken)
            {
                var postList = await _context.Clientes.ToListAsync();
                if (postList == null)
                {
                    return null;
                }
                return postList.AsReadOnly();
            }
        }
        
    }
}
