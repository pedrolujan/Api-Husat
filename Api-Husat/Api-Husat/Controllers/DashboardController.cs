using Api_Husat.Data;
using Api_Husat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Husat.Controllers
{
    [ApiController]
    [Route("Dashboard")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        [Route("ListarContenedores")]
        public dynamic ListarContenedores(int _tipoCon)
        {
            daDashboard dp = new daDashboard();
            List<Dashboard> stDasboard = new List<Dashboard>();
            ResponseData resData = new ResponseData();


            stDasboard = dp.daBuscarCajasDashboard(_tipoCon);
            if (stDasboard.Count>0)
            {
                resData = new ResponseData
                {
                    state = true,
                    message = "Se encontraron resultados",
                    result = stDasboard
                };
            }
                
                return resData;

            
        }

        [HttpGet]
        [Route("ObtenerIngresos")]
        public IActionResult Get([FromQuery] Busquedas busquedas)        
        {
            ResponseData resData = new ResponseData();
            daDashboard daDashboard= new daDashboard();
           var dat =daDashboard.daBuscarDashBoardIngresos(busquedas);

            resData = new ResponseData
            {
                state = true,
                message = "Se encontraron resultados",
                result = new List<object> { dat.Item1, dat.Item2 }
            };

            return Ok(resData);
        }
    }
}
