using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public long Id { get; set; }
        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
        {
            private readonly IClienteRepository _clienteRepository;
            public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
            {
                _clienteRepository = clienteRepository;
            }
            public async Task<Cliente> Handle(GetClienteByIdQuery query, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetById(query.Id);
                if (cliente == null) return null;
                return cliente;
            }
        }

    }
}
