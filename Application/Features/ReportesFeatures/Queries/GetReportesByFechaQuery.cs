using Application.Interfaces;
using MediatR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ReportesFeatures.Queries
{
    public class GetReportesByFechaQuery : IRequest<IEnumerable<JObject>>
    {
        public DateTime Fecha { get; set; }

        public class GetReportesByFechaQueryHandler : IRequestHandler<GetReportesByFechaQuery, IEnumerable<JObject>>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            public GetReportesByFechaQueryHandler(IMovimientoRepository movimientoRepository)
            {
                _movimientoRepository = movimientoRepository;
            }

            public async Task<IEnumerable<JObject>> Handle(GetReportesByFechaQuery query, CancellationToken cancellationToken)
            {
                var movimientos = _movimientoRepository.GetAll();

                if (movimientos == null)
                {
                    return null;
                }
                return null;
            }
        }
    }
}
