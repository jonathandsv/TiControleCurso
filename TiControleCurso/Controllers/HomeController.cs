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

        public List<Aula> InserirAula(List<Aula> listaAulas)
        {
            ControleBO controle = new ControleBO();
            controle.InserirAulas(listaAulas);

            return (null);
        }
    }
}