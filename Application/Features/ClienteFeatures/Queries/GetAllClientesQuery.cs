using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetAllClientesQuery : IRequest<IEnumerable<Cliente>>
    {
        public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<Cliente>>
        {
            private readonly IClienteRepository _clienteRepository;
            public GetAllClientesQueryHandler(IClienteRepository clienteRepository)
            {
                _clienteRepository = clienteRepository;
            }

            public async Task<IEnumerable<Cliente>> Handle(GetAllClientesQuery query, CancellationToken cancellationToken)
            {
                var postList = _clienteRepository.GetAll();
                if (postList == null)
                {
                    return null;
                }
                return postList;
            }
        }

    }
}
