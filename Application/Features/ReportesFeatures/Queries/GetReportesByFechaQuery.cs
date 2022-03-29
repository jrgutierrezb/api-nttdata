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
    public class GetReportesByFechaQuery : IRequest<IEnumerable<object>>
    {
        public DateTime Fecha { get; set; }

        public class GetReportesByFechaQueryHandler : IRequestHandler<GetReportesByFechaQuery, IEnumerable<object>>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IClienteRepository _clienteRepository;
            public GetReportesByFechaQueryHandler(
                IMovimientoRepository movimientoRepository,
                ICuentaRepository cuentaRepository,
                IClienteRepository clienteRepository
                )
            {
                _movimientoRepository = movimientoRepository;
                _cuentaRepository = cuentaRepository;
                _clienteRepository = clienteRepository;
            }

            public async Task<IEnumerable<object>> Handle(GetReportesByFechaQuery query, CancellationToken cancellationToken)
            {
                List<object> reporte = null;
                var movimientos = _movimientoRepository.GetAll();

                if (movimientos == null)
                {
                    return null;
                }

                reporte = new List<object>();
                DateTime now = DateTime.Now;

                foreach(var movimiento in movimientos)
                {
                    if(movimiento.Fecha.ToString("dd/MM/yyyy") == now.ToString("dd/MM/yyyy"))
                    {
                        var cuenta = await _cuentaRepository.GetById(movimiento.CuentaId);
                        var cliente = await _clienteRepository.GetById(cuenta.ClienteId);
                        reporte.Add(new 
                        {
                            Fecha = movimiento.Fecha.ToString("dd/MM/yyyy"),
                            Cliente= cliente.Nombre ,
                            NumeroCuenta = cuenta.NumeroCuenta ,
                            Tipo = cuenta.TipoCuenta == Domain.Entity.Cuenta.TipoCuentas.AHORRO ? "Ahorro" : "Corriente",
                            SaldoInicial = cuenta.SaldoInicial,
                            Estado = cuenta.Estado,
                            Movimiento = movimiento.Valor,
                            SaldoDisponible = movimiento.Saldo
                        });
                    }
                }

                return reporte;
            }
        }
    }
}
