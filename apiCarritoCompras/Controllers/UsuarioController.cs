using apiCarritoCompras.Model;
using apiCarritoCompras.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCarritoCompras.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IJWTService jsonWebToken;

        public UsuarioController(IJWTService jsonWebToken)
        {
            this.jsonWebToken = jsonWebToken;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            cartshopContext db = new cartshopContext();
            LoginResponse objResponse = null;

            if (request.transaccion == "autenticarUsuario")
            {
                var usuario = await db.Usuarios.FirstOrDefaultAsync(x => x.Email == request.datosUsuario.email && x.Clave == request.datosUsuario.password);

                if (usuario != null)
                {
                    string token = jsonWebToken.GenerarToken(usuario);
                    objResponse = new LoginResponse()
                    {
                        codigoRetorno = "0001",
                        mensajeRetorno = "consulta correcta",
                        usuario = usuario,
                        token = token
                    };
                }

                else
                {
                    objResponse = new LoginResponse()
                    {
                        codigoRetorno = "0002",
                        mensajeRetorno = "Usuario o clave incorrecta",
                        usuario = null,
                        token = null
                    };
                }

            }
            else
            {
                objResponse = new LoginResponse()
                {
                    codigoRetorno = "0003",
                    mensajeRetorno = "Transacción no existente",
                    usuario = null,
                    token = null
                };
            }

            return Ok(objResponse);
        }
    }
}
