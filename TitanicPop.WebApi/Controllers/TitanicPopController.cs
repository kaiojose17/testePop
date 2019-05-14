using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TitanicaPop.Commom;
using TitanicPop.Domain.Entities.DTO;
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
            var sobreviventes = _titanicPopService.ObterPassageirosPorSituacao(true);
            return Json(sobreviventes);
        }

        [HttpGet]
        [Route(ApiConstants.Routes.WebApi.Resources.Morreram)]
        public JsonResult Morreram()
        {
            var morreram = _titanicPopService.ObterPassageirosPorSituacao(false);
            return Json(morreram);
        }

        [HttpGet]
        [Route(ApiConstants.Routes.WebApi.Resources.Classe)]
        public JsonResult PassageirosPorClasse()
        {
            var passageirosPorClasse = _titanicPopService.ObterPassageirosPorClasse();
            return Json(passageirosPorClasse);
        }

        [HttpPost]
        public ActionResult FiltroPassageiros(FiltroDTO filtro)
        {
            IList<string> erros;

            try
            {
                _titanicPopService.ValidarJson(filtro, out erros);

                if (erros.Count > 0)
                    throw new ArgumentException(string.Join(",", erros));

                var pessoas = _titanicPopService.NumeroPessoasEncontradas(filtro);

                return StatusCode((int)HttpStatusCode.OK, pessoas);
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, $"A requisição não é válida: {ex.Message}");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
    }
}
