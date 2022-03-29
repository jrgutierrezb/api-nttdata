using Application.Features.MovimientoFeatures.Commands;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Commands
{
    public class UpdateMovimientoCommand : IRequest<long>
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimientos TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long CuentaId { get; set; }

        public enum TipoMovimientos
        {
            DEBITO,
            CREDITO
        }
        public class UpdateMovimientoCommandHandler : IRequestHandler<UpdateMovimientoCommand, long>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            public UpdateMovimientoCommandHandler(IMovimientoRepository movimientoRepository)
            {
                _movimientoRepository = movimientoRepository;
            }

            public async Task<long> Handle(UpdateMovimientoCommand command, CancellationToken cancellationToken)
            {
                var cuenta = await _movimientoRepository.GetById(command.Id);

                if (cuenta == null)
                {
                    return default;
                }
                else
                {
                    cuenta.Id = command.Id;
                    cuenta.Fecha = command.Fecha;
                    cuenta.TipoMovimiento = (Movimiento.TipoMovimientos)command.TipoMovimiento;
                    cuenta.Valor = command.Valor;
                    cuenta.Saldo = command.Saldo;
                    cuenta.CuentaId = command.CuentaId;
                    _movimientoRepository.Update(cuenta);
                    return cuenta.Id;
                }
            }
        }
    
    }
}
