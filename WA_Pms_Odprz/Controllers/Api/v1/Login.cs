using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BR_App.AppViewModels;
using BR_BussinesRules.BrApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WA_Pms_Odprz.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        #region BR Instance
        private readonly AppBr _br = new AppBr();
        #endregion

        [HttpPost]
        public ActionResult<UserViewModel>UserLogin(UserLoginViewModel model)
        {
            try
            {
                
                var result = _br.Login(model);
                if (result != null)
                    return result;
                return BadRequest("El usuario o la contraseña no es valida");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
