using apiCarritoCompras.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Controllers
{

    [ApiController]
    [Authorize]
    [Route("planes")]
    public class PlanesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]  PlanRequest request)
        {
            cartshopContext db = new cartshopContext();
            PlanResponse objResponse = null;

            if (request.transaccion == "consultarPlanes")
            {
                var objPlanes = await db.Planes.ToListAsync();

                if (objPlanes != null)
                {
                    objResponse = new PlanResponse()
                    {
                        codigoRetorno = "0001",
                        retorno = objPlanes
                    };
                }

                else
                {
                    objResponse = new PlanResponse()
                    {
                        codigoRetorno = "0002",
                        retorno = null
                    };
                }

            }
            else
            {

                objResponse = new PlanResponse()
                {
                    codigoRetorno = "0003",
                    retorno = null
                };

            }

            return Ok(objResponse);
        }
        
    }
}
