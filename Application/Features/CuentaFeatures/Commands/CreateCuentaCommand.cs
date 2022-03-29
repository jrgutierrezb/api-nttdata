using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Commands
{
    public class CreateCuentaCommand : IRequest<long>
    {
        public string NumeroCuenta { get; set; }
        public TipoCuentas TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }
        public enum TipoCuentas
        {
            AHORRO,
            CORRIENTE
        }
        public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand, long>
        {
            private readonly ICuentaRepository _cuentaRepository;
            public CreateCuentaCommandHandler(ICuentaRepository cuentaRepository)
            {
                _cuentaRepository = cuentaRepository;
            }

            public async Task<long> Handle(CreateCuentaCommand command, CancellationToken cancellationToken)
            {
                var cuenta = new Cuenta
                {
                    NumeroCuenta = command.NumeroCuenta,
                    TipoCuenta = (Cuenta.TipoCuentas)command.TipoCuenta,
                    SaldoInicial = command.SaldoInicial,
                    Estado = command.Estado,
                    ClienteId = command.ClienteId
                };
                await _cuentaRepository.Add(cuenta);
                return cuenta.Id;
            }
        }
    }
}
