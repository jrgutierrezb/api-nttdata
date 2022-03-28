using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Commands
{
    public class CreateClienteCommand : IRequest<long>
    {
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
        public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public CreateClienteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateClienteCommand command, CancellationToken cancellationToken)
            {
                var post = new Cliente
                {
                    Nombre = command.Nombre,
                    Genero = (Persona.Generos)command.Genero,
                    FechaNacimiento = command.FechaNacimiento,
                    Identificacion = command.Identificacion,
                    Direccion = command.Direccion,
                    Telefono = command.Telefono,
                    Contrasena = command.Contrasena,
                    Estado = command.Estado
                };
                _context.Clientes.Add(post);
                await _context.SaveChangesAsync();
                return post.Id;
            }
        }
    }
}
