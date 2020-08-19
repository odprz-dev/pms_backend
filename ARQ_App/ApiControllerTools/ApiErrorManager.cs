using ARQ_App.ExceptionManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARQ_App.ApiControllerTools
{
    public  class ApiErrorManager : ControllerBase
    {
        /// <summary>
        /// Retorna un BadRequest devido a un error de validacion en la operacion.
        /// </summary>
        /// <param name="e">OperationValidationException</param>
        /// <returns>IActionResult</returns>
        protected ActionResult BadRequest(OperationValidationException e)
        {
            foreach (var error in e.StackMsg)
                ModelState.AddModelError(error.Key, error.Value);
            return BadRequest(ModelState);
        }
    }
}
