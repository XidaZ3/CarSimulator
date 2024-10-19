using CarSimulator.DTOs;
using CarSimulator.DTOs.Cars.Bodies;
using CarSimulator.DTOs.Cars.Requests;
using CarSimulator.Exceptions;
using CarSimulator.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace CarSimulator.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult HandleError(Exception ex)
        {
            if (ex is UnprocessableEntityException customEx)
            {
                return UnprocessableEntity(new { error = customEx.Message });
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, new { error = ex.Message });
        }
    }
}
