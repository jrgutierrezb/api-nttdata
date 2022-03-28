using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Queries
{
    public class GetAllCuentasQuery : IRequest<IEnumerable<Cuenta>>
    {
        public class GetAllCuentasQueryHandler : IRequestHandler<GetAllCuentasQuery, IEnumerable<Cuenta>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCuentasQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Cuenta>> Handle(GetAllCuentasQuery query, CancellationToken cancellationToken)
            {
                var cuentas = await _context.Cuentas.ToListAsync();
                if (cuentas == null)
                {
                    return null;
                }
                return cuentas.AsReadOnly();
            }
        }
    }
}
