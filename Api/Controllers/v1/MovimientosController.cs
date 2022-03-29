using Application.Features.MovimientoFeatures.Commands;
using Application.Features.MovimientoFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    public class MovimientosController : BaseApiController
    {
        /// <summary>
        /// Creates a New Movimiento.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovimientoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Movimientos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllMovimientosQuery()));
        }

        /// <summary>
        /// Gets Movimiento Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetMovimientoByIdQuery { Id = id }));
        }

        /// <summary>
        /// Updates the Movimiento Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateMovimientoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
