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
            private readonly IMovimientoRepository _movimientoRepository;
            public GetMovimientoByIdQueryHandler(IMovimientoRepository movimientoRepository)
            {
                _movimientoRepository = movimientoRepository;
            }
            public async Task<Movimiento> Handle(GetMovimientoByIdQuery query, CancellationToken cancellationToken)
            {
                var movimiento = await _movimientoRepository.GetById(query.Id);
                if (movimiento == null) return null;
                return movimiento;
            }
        }
    }
}
