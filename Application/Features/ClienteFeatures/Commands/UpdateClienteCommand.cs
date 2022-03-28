using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Commands
{
    public class UpdateClienteCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Generos Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

        public enum Generos
        {
            MASCULINO,
            FEMENINO
        }
        public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, long>
        {
            private readonly IClienteRepository _clienteRepository;
            public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
            {
                _clienteRepository = clienteRepository;
            }

            public async Task<long> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetById(command.Id);

                if (cliente == null)
                {
                    return default;
                }
                else
                {
                    cliente.Id = command.Id;
                    cliente.Nombre = command.Nombre;
                    cliente.Genero = (Persona.Generos)command.Genero;
                    cliente.FechaNacimiento = command.FechaNacimiento;
                    cliente.Identificacion = command.Identificacion;
                    cliente.Direccion = command.Direccion;
                    cliente.Telefono = command.Telefono;
                    cliente.Contrasena = command.Contrasena;
                    cliente.Estado = command.Estado;
                    _clienteRepository.Update(cliente);
                    return cliente.Id;
                }
            }
        }
    }
}
