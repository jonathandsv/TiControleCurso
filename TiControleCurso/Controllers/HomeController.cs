using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiControleCurso.Models;

namespace TiControleCurso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult InserirAulas(string listaAulas)
        {
            var listaConvertida = JsonConvert.DeserializeObject<List<Aula>>(listaAulas);
            ControleBO controle = new ControleBO();
            controle.InserirAulas(listaConvertida);

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}