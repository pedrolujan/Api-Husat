using Api_Husat.Data;
using Api_Husat.General;
using Api_Husat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Husat.Controllers
{
    [ApiController]
    [Route("/General")]
    public class GeneralController : ControllerBase
    {
        [HttpGet]
        [Route("LlenarCombobox")]
        public dynamic fnDevolberDatosCombobox(String _CodTab, Boolean _buscar)
        {
            List<Combobox> lstTablaCod = new List<Combobox>();
            ResponseData resData = new ResponseData();
            if (_CodTab is not null )
            {
                lstTablaCod = gFunciones.fnLlenarTablaCodTipoCon( _CodTab,  _buscar);
                if (lstTablaCod.Count > 0)
                {
                    resData = new ResponseData
                    {
                        state = true,
                        message = "Datos encontrados",
                        result = lstTablaCod
                    };
                }
                else
                {
                    resData = new ResponseData
                    {
                        state = false,
                        message = "No se encontraron resultados",
                        result = lstTablaCod
                    };

                }
            }
            else
            {
                resData = new ResponseData
                {
                    state = false,
                    message = "Envie codigo correcto",
                    result = lstTablaCod
                };
            }


            return resData;


        }

        [HttpGet]
        [Route("LlenarUsuariosConAccion")]
        public dynamic fnDevolverUsuarioPorFechas(Boolean _habilitarFechas,DateTime _dFechaInicial, DateTime _dFechaFinal,Boolean _bEstado,Int32 _idUsuario)
        {
            List<Usuario> lstUsuario=new List<Usuario>();
            ResponseData resData = new ResponseData();
            lstUsuario = gFunciones.fnLlenarUsuariosConAccion(_habilitarFechas,_dFechaInicial,_dFechaFinal,_bEstado,_idUsuario);
            if (lstUsuario.Count>0)
            {
                resData = new ResponseData
                {
                    state = true,
                    message = "Datos encontrados",
                    result = lstUsuario
                };
            }
            else
            {
                resData = new ResponseData
                {
                    state = false,
                    message = "No se encontraron resultados",
                    result = lstUsuario
                };

            }
            return resData; 
        }

        [HttpGet]
        [Route("LlenarComboboxSegunTabla")]
        public dynamic fnLlenarcboSegunTabla(String _nomCombobox,String _nomCampoId, String _nomCampoNombre, String _nomTabla, String _nomEstado, String _condicionDeEstado, Boolean _buscar)
        {
            List<Combobox> lstTablaCod = new List<Combobox>();
            ResponseData resData = new ResponseData();
            if (_nomTabla is not null)
            {
                lstTablaCod = gFunciones.blLlenarCboSegunTablaTipoCon(_nomCampoId, _nomCampoNombre, _nomTabla, _nomEstado, _condicionDeEstado, _buscar);
                if (_nomCombobox == "cboFiltrarIngresos")
                {
                    Int32 i = 0;

                    foreach (Combobox it in lstTablaCod)
                    {
                        if (it.cCodTab == "16")
                        {
                            lstTablaCod[i].cCodTab = "-16";
                            lstTablaCod[i].cNomTab = "GPS";
                        }
                        i++;
                    }
                    lstTablaCod.Add(new Combobox
                    {
                        cCodTab = "16",
                        cNomTab = "CAJA CHICA"
                    });
                }

                if (lstTablaCod.Count > 0)
                {
                    resData = new ResponseData
                    {
                        state = true,
                        message = "Datos encontrados",
                        result = lstTablaCod
                    };
                }
                else
                {
                    resData = new ResponseData
                    {
                        state = false,
                        message = "No se encontraron resultados",
                        result = lstTablaCod
                    };

                }
            }
            else
            {
                resData = new ResponseData
                {
                    state = false,
                    message = "Envie todos los parametros requeridos",
                    result = lstTablaCod
                };
            }


            return resData;


        }
        [HttpGet]
        [Route("obtener-importe-caja")]
        public dynamic fnObtenerImporteMoneda(DateTime _fechaActual,Int32 _idUsuario)
        {
            gFunciones gFunciones=new gFunciones();
            ResponseData resData = new ResponseData();
            List<CajaChica> list = new List<CajaChica>();

            list = gFunciones.fnObtenerImporteCaja(_fechaActual, _idUsuario);
            if (list.Count > 0)
            {
                resData = new ResponseData
                {
                    state = true,
                    message = "Datos encontrados",
                    result = list
                };
            }
            else
            {
                resData = new ResponseData
                {
                    state = false,
                    message = "No se encontraron resultados",
                    result = list
                };

            }
            return resData;

        }

    }

}
