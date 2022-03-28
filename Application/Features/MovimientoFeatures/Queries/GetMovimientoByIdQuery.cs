using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Queries
{
    public class GetMovimientoByIdQuery : IRequest<Movimiento>
    {
        public long Id { get; set; }
        public class GetMovimientoByIdQueryHandler : IRequestHandler<GetMovimientoByIdQuery, Movimiento>
        {
            private readonly IApplicationDbContext _context;
            public GetMovimientoByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Movimiento> Handle(GetMovimientoByIdQuery query, CancellationToken cancellationToken)
            {
                var movimiento = _context.Movimientos.FirstOrDefault(a => a.Id == query.Id);
                if (movimiento == null) return null;
                return movimiento;
            }
        }
    }
}
