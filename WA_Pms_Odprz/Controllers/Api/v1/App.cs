using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARQ_App.ApiControllerTools;
using ARQ_App.ExceptionManager;
using BR_App.AppViewModels;
using BR_BussinesRules.BrApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WA_Pms_Odprz.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class App : ApiErrorManager
    {
        #region BR Instance
        private readonly AppBr _br = new AppBr();
        #endregion

        // GET: api/app/Classifications
        /// <summary>
        /// Retorna un listado de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        public ActionResult<IEnumerable<UserViewModel>>GetUsers() 
        {
            try
            {
                return Ok(_br.GetUsers());
            }
            catch (OperationValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
                // TODO: HandleExceptions
            }
        }

        // GET: api/app/Users/asdasdaasdasd
        /// <summary>
        /// Retorna un usuario por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Users/{id}")]
        public ActionResult<UserViewModel>GetUserById(string id)
        {
            try
            {
                var user = _br.GetUserById(id);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (OperationValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
                // TODO: HandleExceptions

            }
        }

        // POST: api/app/Users
        /// <summary>
        /// Agrega un nuevo registro de usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Users")]
        public ActionResult<UserViewModel>PostUser(UserViewModel model)
        {
            try
            {
                return Ok(_br.PostUser(model));
            }
            catch (OperationValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
                // TODO: HandleExceptions DbUpdateException

            }
        }

        // PUT: api/app/Users/asdasdasdas
        /// <summary>
        ///  Edita un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Users/{id}")]
        public ActionResult<UserViewModel>PutUser(string id, UserEditViewModel model)
        {
            try
            {
                if(id != model.PkIdUser)
                {
                    return BadRequest();
                }
                var result = _br.PutUser(id, model);
                if (result != null)
                    return result;
                return NotFound();
            }
            catch (OperationValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // DELETE: api/app/Users/asdasdasda
        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Users/{id}")]
        public ActionResult<UserViewModel>DeleteUser(string id)
        {
            try
            {
                var result = _br.DeleteUser(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (OperationValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
                // TODO: HandleExceptions

            }
        }

    }
}
