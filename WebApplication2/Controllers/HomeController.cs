using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _message;

        public HomeController(IMessageService message)
        {
            _message = message;
        }

        public ActionResult Index()
        {
            var result = _message.Send("Hello DI");

            ViewBag.Message = result;

            return View();
        }
    }

    public interface IMessageService
    {
        string Send(string message);
    }

    public class EMail : IMessageService
    {
        public string Send(string message)
        {
            return "Autofac-" + message;
        }
    }
}