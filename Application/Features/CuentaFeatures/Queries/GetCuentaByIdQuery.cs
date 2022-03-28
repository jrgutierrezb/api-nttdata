using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Queries
{
    public class GetCuentaByIdQuery : IRequest<Cuenta>
    {
        public long Id { get; set; }
        public class GetCuentaByIdQueryHandler : IRequestHandler<GetCuentaByIdQuery, Cuenta>
        {
            private readonly ICuentaRepository _cuentaRepository;
            public GetCuentaByIdQueryHandler(ICuentaRepository cuentaRepository)
            {
                _cuentaRepository = cuentaRepository;
            }
            public async Task<Cuenta> Handle(GetCuentaByIdQuery query, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetById(query.Id);
                if (cuenta == null) return null;
                return cuenta;
            }
        }

    }
}
