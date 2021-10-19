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
    [Route("productos")]
    public class ProductosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoRequest request)
        {
            cartshopContext db = new cartshopContext();
            ProductoResponse objResponse = null;

            if (request.transaccion == "generico" && request.tipo == 4)
            {
                var objPlanes = await db.Productos.Where(x => x.Estado == true).ToListAsync();

                if (objPlanes != null)
                {
                    objResponse = new ProductoResponse()
                    {
                        codigoRetorno = "0001",
                        mensajeRetorno = "Consulta Ok",
                        data = objPlanes
                    };
                }

                else
                {
                    objResponse = new ProductoResponse()
                    {
                        codigoRetorno = "0002",
                        mensajeRetorno = "No hay productos",
                        data = null
                    };
                }

            }
            else
            {

                objResponse = new ProductoResponse()
                {
                    codigoRetorno = "0003",
                    mensajeRetorno = "Transacción no existente",
                    data = null
                };

            }

            return Ok(objResponse);
        }
        
    }
}
