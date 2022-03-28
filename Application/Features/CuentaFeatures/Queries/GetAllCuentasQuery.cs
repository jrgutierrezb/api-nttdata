using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Queries
{
    public class GetAllCuentasQuery : IRequest<IEnumerable<Cuenta>>
    {
        public class GetAllCuentasQueryHandler : IRequestHandler<GetAllCuentasQuery, IEnumerable<Cuenta>>
        {
            private readonly ICuentaRepository _cuentaRepository;
            public GetAllCuentasQueryHandler(ICuentaRepository cuentaRepository)
            {
                _cuentaRepository = cuentaRepository;
            }

            public async Task<IEnumerable<Cuenta>> Handle(GetAllCuentasQuery query, CancellationToken cancellationToken)
            {
                var cuentas = _cuentaRepository.GetAll();
                if (cuentas == null)
                {
                    return null;
                }
                return cuentas;
            }
        }
    }
}
