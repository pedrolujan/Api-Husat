using Api_Husat.General;
using Api_Husat.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Net;
namespace Api_Husat.Controllers
{
    [ApiController]
    [Route("consultas")]
    public class ConsultasController:ControllerBase
    {
        [HttpGet]
        [Route("buscar-consultas")]
        public dynamic fnBuscarConsultas(String _pcBuscar,Int32 _tipoCon)
        {
            gFunciones buscar = new gFunciones();
            ResponseData resData = new ResponseData();
            List<Consultas> lstConsultas = new List<Consultas>();
            lstConsultas = buscar.blBuscarConsultas(_pcBuscar,  _tipoCon);
            if (lstConsultas.Count > 0)
            {

                resData = new ResponseData
                {
                    state = true,
                    message = "Datos encontrados",
                    result = lstConsultas,
                };
             
            }
            else
            {
                resData = new ResponseData
                {
                    state = false,
                    message = "No se encontraron resultados",
                    result = lstConsultas
                };

            }
            return resData ;

        } 
    }
}
