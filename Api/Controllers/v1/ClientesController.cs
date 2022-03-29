using Application.Features.ClienteFeatures.Commands;
using Application.Features.ClienteFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    public class ClientesController : BaseApiController
    {
        /// <summary>
        /// Creates a New Cliente.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllClientesQuery()));
        }

        /// <summary>
        /// Gets Cliente Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetClienteByIdQuery { Id = id }));
        }

        /// <summary>
        /// Updates the Cliente Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateClienteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
