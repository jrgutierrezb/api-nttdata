using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Queries
{
    public class GetAllMovimientosQuery : IRequest<IEnumerable<Movimiento>>
    {
        public class GetAllMovimientosQueryHandler : IRequestHandler<GetAllMovimientosQuery, IEnumerable<Movimiento>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllMovimientosQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Movimiento>> Handle(GetAllMovimientosQuery query, CancellationToken cancellationToken)
            {
                var movimientos = await _context.Movimientos.ToListAsync();
                if (movimientos == null)
                {
                    return null;
                }
                return movimientos.AsReadOnly();
            }
        }
    }
}
