using Api_Husat.Data;
using Api_Husat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Husat.Controllers
{

    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]
        public dynamic ListarCliente()
        {
            List<Cliente> lstCliente = new List<Cliente>();

            lstCliente.Add(new Cliente
            {
                Id = 1,
                nombres = "Julio",
                Edad = 25,
                Celular = "Dia@gmail.com"
            });





            return lstCliente;


        }

        [HttpPost]
        [Route("Guardar")]
        public dynamic Guardar(Cliente clsCliente)
        {
            clsCliente.Id = 1;

            return new
            {
                sucsess = true,
                message = "Cliente guardado exitosamente",
                result = clsCliente
            };

        }

        [HttpGet]
        [Route("ListarXId")]
        public dynamic ListaCliente(int _id, int _tipoCon)
        {
            daCliente dc = new daCliente();
            return dc.fnListarClientes(_id, _tipoCon);
        }
    }
}
