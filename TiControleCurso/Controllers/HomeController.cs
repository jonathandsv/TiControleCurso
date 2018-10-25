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
            List<int> construcao = new List<int>();
            List<Aula> aulasencontradas = new List<Aula>();

            for (int i = 0; i < listaConvertida.Count; i++)
            {
                construcao.Add(listaConvertida[i].Construcao);
            }

            aulasencontradas = controle.BuscarAula(construcao);

            if (aulasencontradas.Count == 0)
            {
                controle.InserirAulas(listaConvertida);
            }
            //else
            //{
            //    for (int i = 0; i < aulasencontradas.Count; i++)
            //    {
            //        aulasencontradas[i].Construcao != listaConvertida[];
            //    }
            //}
            

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}