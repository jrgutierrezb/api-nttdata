using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Commands
{
    public class CreateMovimientoCommand : IRequest<long>
    {
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
        public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public CreateMovimientoCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateMovimientoCommand command, CancellationToken cancellationToken)
            {
                var cuenta = new Movimiento
                {
                    Fecha = command.Fecha,
                    TipoMovimiento = (Movimiento.TipoMovimientos)command.TipoMovimiento,
                    Valor = command.Valor,
                    Saldo = command.Saldo,
                    CuentaId = command.CuentaId
                };
                _context.Movimientos.Add(cuenta);
                await _context.SaveChangesAsync();
                return cuenta.Id;
            }
        }
    
    }
}
