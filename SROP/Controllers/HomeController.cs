using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SROP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            //BE_USUARIO i = new BE_USUARIO();
            //i.UserId = "jabregu";
            //i.NombreUsuario = "Jonatán Abregú Chalco";
            //Yoo.Yo(i.Serializar());
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
    }
}