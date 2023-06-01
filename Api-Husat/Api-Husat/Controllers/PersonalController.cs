using Api_Husat.Data;
using Api_Husat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Husat.Controllers
{
    [ApiController]
    [Route("Personal")]
    public class PersonalController
    {
        [HttpGet]
        [Route("Login")]
        public dynamic AccederAlSistema(string _pcUsuario, string _clave)
        {
            daPersonal dp = new daPersonal();
            Personal personal = new Personal();
            ResponseData resData = new ResponseData();

            if (_pcUsuario is not null && _clave is not null)
            {
                personal = dp.fnAccederSistema(_pcUsuario, _clave);
                if (personal.IdAcceso == 1)
                {
                    resData = new ResponseData
                    {
                        state = true,
                        message = "Bienvedido al sistema",
                        result = personal
                    };
                }
                else if (personal.IdAcceso == 2)
                {
                    resData = new ResponseData
                    {
                        state = false,
                        message = "Contraseña incorrecta",
                        result = new Personal()
                    };
                }
                else if (personal.IdAcceso == 3)
                {
                    resData = new ResponseData
                    {
                        state = false,
                        message = "Usuario no existe",
                        result = new Personal()
                    };
                }
                else if (personal.IdAcceso == 4)
                {
                    resData = new ResponseData
                    {
                        state = false,
                        message = "Usuario inactivo",
                        result = new Personal()
                    };
                }
                return resData;

            }
            else
            {
                return new
                {
                    sucsess = false,
                    message = "Ingrese Usuario y contraseña",
                    result = personal
                };
            }
        }
    }
}
