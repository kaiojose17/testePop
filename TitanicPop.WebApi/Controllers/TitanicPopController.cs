using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TitanicaPop.Commom;
using TitanicPop.Domain.Services;

namespace TitanicPop.WebApi.Controllers
{
    [Route(ApiConstants.Routes.WebApi.BaseUri)]
    [ApiController]
    public class TitanicPopController : Controller
    {
        private readonly ITitanicPopService _titanicPopService;

        public TitanicPopController(ITitanicPopService titanicPopService)
        {
            _titanicPopService = titanicPopService;
        }


        [HttpGet]
        [Route(ApiConstants.Routes.WebApi.Resources.Sobreviventes)]
        public JsonResult Sobreviventes()
        {
            var sobreviventes = _titanicPopService.GetAll();
            return Json(new string[] { "value1", "value2" });
        }

        
    }
}
