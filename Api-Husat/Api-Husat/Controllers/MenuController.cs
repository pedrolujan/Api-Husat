using Api_Husat.General;
using Api_Husat.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text;

namespace Api_Husat.Controllers
{
    [ApiController]
    [Route("menu")]
    public class MenuController:ControllerBase
    {
        [HttpGet]
        [Route("listar-accesos")]
        public dynamic  fnListarAcceso(Int32 _idUsuario, Int32 _idAplicacion)
        {
            gFunciones gfunciones = new gFunciones();
            DataSet dataSet = new DataSet();
            ResponseData resData = new ResponseData();
            try
            {
                dataSet = gfunciones.BLCargarMenu(_idUsuario, _idAplicacion);
                if (dataSet.Tables.Count > 0)
                {
                    resData = new ResponseData
                    {
                        state = true,
                        message = "Datos Encontrados",
                        result = dataSet.Tables[0]
                    };
                }
                else
                {
                    resData = new ResponseData
                    {
                        state = false,
                        message = "No se encontraron resultados",
                        result = dataSet.Tables[0]
                    };

                }

                // Convertir el objeto ResponseData a JSON
                var json = JsonConvert.SerializeObject(resData);

               var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                return json;


            }
            catch (Exception ex)
            {
                resData = new ResponseData
                {
                    state = false,
                    message = "No se encontraron resultados",
                    result = dataSet
                };
            }
            
            return resData;
        }

        private dynamic ResponseMessage(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }
    }
}
