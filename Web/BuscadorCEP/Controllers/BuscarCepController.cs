using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscadorCEP.Controllers
{
	public class BuscarCepController : Controller
	{
		[Route("BuscadorCEP/BuscarCEP")]
		public ActionResult Index()
		{
			List<KeyValuePair<string, string>> estados = PreencheEstados();

			ViewBag.Estados = estados;

			return View();
		}

		private List<KeyValuePair<string, string>> PreencheEstados()
		{
			List<KeyValuePair<string, string>> estados = new List<KeyValuePair<string, string>>();

			estados.Add(new KeyValuePair<string, string>("AC", "Acre"));
			estados.Add(new KeyValuePair<string, string>("AL", "Alagoas"));
			estados.Add(new KeyValuePair<string, string>("AP", "Amapa"));
			estados.Add(new KeyValuePair<string, string>("AM", "Amazonas"));
			estados.Add(new KeyValuePair<string, string>("BA", "Bahia"));
			estados.Add(new KeyValuePair<string, string>("CE", "Ceara"));
			estados.Add(new KeyValuePair<string, string>("DF", "Distrito Federal"));
			estados.Add(new KeyValuePair<string, string>("ES", "Espirito Santo"));
			estados.Add(new KeyValuePair<string, string>("GO", "Goias"));
			estados.Add(new KeyValuePair<string, string>("MA", "Maranhao"));
			estados.Add(new KeyValuePair<string, string>("MT", "Mato Grosso"));
			estados.Add(new KeyValuePair<string, string>("MS", "Mato Grosso do Sul"));
			estados.Add(new KeyValuePair<string, string>("MG", "Minas Gerais"));
			estados.Add(new KeyValuePair<string, string>("PA", "Para"));
			estados.Add(new KeyValuePair<string, string>("PB", "Paraiba"));
			estados.Add(new KeyValuePair<string, string>("PR", "Parana"));
			estados.Add(new KeyValuePair<string, string>("PE", "Pernambuco"));
			estados.Add(new KeyValuePair<string, string>("PI", "Piaui"));
			estados.Add(new KeyValuePair<string, string>("RJ", "Rio de Janeiro"));
			estados.Add(new KeyValuePair<string, string>("RN", "Rio Grande do Norte"));
			estados.Add(new KeyValuePair<string, string>("RS", "Rio Grande do Sul"));
			estados.Add(new KeyValuePair<string, string>("RO", "Rondonia"));
			estados.Add(new KeyValuePair<string, string>("RR", "Roraima"));
			estados.Add(new KeyValuePair<string, string>("SC", "Santa Catarina"));
			estados.Add(new KeyValuePair<string, string>("SP", "Sao Paulo"));
			estados.Add(new KeyValuePair<string, string>("SE", "Sergipe"));
			estados.Add(new KeyValuePair<string, string>("TO", "Tocantins"));

			return estados;
		}
	}
}
