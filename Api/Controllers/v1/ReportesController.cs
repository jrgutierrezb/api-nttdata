using Application.Features.ReportesFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    public class ReportesController : BaseApiController
    {

        /// <summary>
        /// Gets Movimiento Entity by Id.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(DateTime fecha)
        {
            return Ok(await Mediator.Send(new GetReportesByFechaQuery { Fecha = fecha } ));
        }
    }
}
