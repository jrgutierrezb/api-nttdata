using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Commands
{
    public class UpdateCuentaCommand : IRequest<long>
    {
        public long Id { get; set; }
        public int NumeroCuenta { get; set; }
        public TipoCuentas TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }
        public enum TipoCuentas
        {
            AHORRO,
            CORRIENTE
        }
        public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCuentaCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(UpdateCuentaCommand command, CancellationToken cancellationToken)
            {
                var cuenta = _context.Cuentas.Where(a => a.Id == command.Id).FirstOrDefault();

                if (cuenta == null)
                {
                    return default;
                }
                else
                {
                    cuenta.Id = command.Id;
                    cuenta.NumeroCuenta = command.NumeroCuenta;
                    cuenta.TipoCuenta = (Cuenta.TipoCuentas)command.TipoCuenta;
                    cuenta.SaldoInicial = command.SaldoInicial;
                    cuenta.Estado = command.Estado;
                    cuenta.ClienteId = command.ClienteId;
                    await _context.SaveChangesAsync();
                    return cuenta.Id;
                }
            }
        }
    }
}
