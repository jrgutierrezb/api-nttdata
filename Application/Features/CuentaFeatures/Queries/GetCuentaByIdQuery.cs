using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Queries
{
    public class GetCuentaByIdQuery : IRequest<Cuenta>
    {
        public long Id { get; set; }
        public class GetCuentaByIdQueryHandler : IRequestHandler<GetCuentaByIdQuery, Cuenta>
        {
            private readonly IApplicationDbContext _context;
            public GetCuentaByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Cuenta> Handle(GetCuentaByIdQuery query, CancellationToken cancellationToken)
            {
                var cuenta = _context.Cuentas.FirstOrDefault(a => a.Id == query.Id);
                if (cuenta == null) return null;
                return cuenta;
            }
        }
    
    }
}
