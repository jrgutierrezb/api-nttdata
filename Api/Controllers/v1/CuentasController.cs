using Application.Features.CuentaFeatures.Commands;
using Application.Features.CuentaFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    public class CuentasController : BaseApiController
    {
        /// <summary>
        /// Creates a New Cuenta.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCuentaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Cuentas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCuentasQuery()));
        }

        /// <summary>
        /// Gets Cuenta Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCuentaByIdQuery { Id = id }));
        }

        /// <summary>
        /// Updates the Cuenta Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateCuentaCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
