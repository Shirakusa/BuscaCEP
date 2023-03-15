using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscadorCEP.Controllers
{
	public class BuscarEnderecoController : Controller
	{
		[Route("BuscadorCEP/BuscarEndereco/{cep?}")]
		public ActionResult Index(string cep)
		{
			if (cep == null)
				return View();
			else
			{
				ViewBag.Cep = cep;
				return View("Resultado");
			}
		}
	}
}
