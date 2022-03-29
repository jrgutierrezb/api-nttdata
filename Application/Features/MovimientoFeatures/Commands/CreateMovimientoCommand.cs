using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Commands
{
    public class CreateMovimientoCommand : IRequest<string>
    {
        public DateTime Fecha { get; set; }
        public TipoMovimientos TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public long CuentaId { get; set; }

        public enum TipoMovimientos
        {
            DEBITO,
            CREDITO 
        }
        public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, string>
        {
            private readonly IConfiguration _configuration;
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IMovimientoRepository _movimientoRepository;
            public CreateMovimientoCommandHandler(
                IMovimientoRepository movimientoRepository,
                ICuentaRepository cuentaRepository,
                IConfiguration configuration
                )
            {
                _movimientoRepository = movimientoRepository;
                _cuentaRepository = cuentaRepository;
                _configuration = configuration;
            }

            public async Task<string> Handle(CreateMovimientoCommand command, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetById(command.CuentaId);
                if(cuenta.SaldoInicial == 0 && command.TipoMovimiento == TipoMovimientos.DEBITO)
                {
                    return "Saldo no disponible";
                }

                if(command.TipoMovimiento == TipoMovimientos.DEBITO)
                {
                    if (ValidaMontoMaximo(command.CuentaId, command.Valor))
                    {
                        return "Cupo diario Excedido";
                    }
                }

                

                decimal saldo = cuenta.SaldoInicial + command.Valor;
                
                var movimiento = new Movimiento
                {
                    Fecha = command.Fecha,
                    TipoMovimiento = (Movimiento.TipoMovimientos)command.TipoMovimiento,
                    Valor = command.Valor,
                    Saldo = saldo,
                    CuentaId = command.CuentaId
                };
                await _movimientoRepository.Add(movimiento);
                return "Proceso Ok";
            }

            private bool ValidaMontoMaximo(long CuentaId, decimal valor)
            {
                DateTime now = DateTime.Now;
                decimal debitoTotal = 0;
                decimal montoMaximo = decimal.Parse(this._configuration["MontoMaximo"]);
                
                var movimientos = _movimientoRepository.Find(x => x.CuentaId == CuentaId);
                
                foreach(var movimiento in movimientos)
                {
                    if(movimiento.Fecha.ToString("dd/MM/yyyy") == now.ToString("dd/MM/yyyy"))
                    {
                        debitoTotal += movimiento.Valor;
                    }
                }

                decimal total = debitoTotal + valor;

                return total < (montoMaximo*(-1));
            }
        }
    
    }
}
