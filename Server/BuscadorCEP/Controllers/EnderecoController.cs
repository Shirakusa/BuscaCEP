using BuscadorCEP.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Unicode;
using System.Net;

namespace BuscadorCEP.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EnderecoController : ControllerBase
	{
		private List<Localidade> localidadesLista = new List<Localidade>();
		private List<Logradouro> logradourosLista = new List<Logradouro>();
		private readonly string pathLocalizacao = $"{System.AppContext.BaseDirectory}/Data/LOG_LOCALIDADE.txt";
		private readonly string pathLogradouro = $"{System.AppContext.BaseDirectory}/Data/LOG_LOGRADOURO_SC.txt";


		public EnderecoController() : base()
		{
			localidadesLista = CarregaLocalizacoes();
			logradourosLista = CarregaLogradouros();
		}

		[HttpGet("BuscaEndereco")]
		public Localidade BuscaEndereco(string cep)
		{
			try
			{
				Logradouro logradouro = logradourosLista.SingleOrDefault(x => x.Cep == cep);

				if (logradouro != null)
				{
					Localidade localidade = localidadesLista.SingleOrDefault(x => x.CodigoMunicipio == logradouro.CodigoMunicipio);

					localidade.Logradouro = logradouro;

					return localidade;
				}
				else
				{
					return new Localidade();
				}
			}
			catch (Exception e)
			{
				return new Localidade();
			}
		}

		[HttpGet("BuscaCep")]
		public Localidade BuscaCep(string estado, long codigoMunicipio, long codigoLogradouro)
		{
			try
			{
				Logradouro logradouro = new Logradouro();

				Localidade localidade = localidadesLista.SingleOrDefault(x => x.UnidadeFederativa == estado && x.CodigoMunicipio == codigoMunicipio);

				if (localidade != null)
				{
					logradouro = logradourosLista.SingleOrDefault(x => x.CodigoMunicipio == localidade.CodigoMunicipio && x.CodigoLogradouro == codigoLogradouro);

					localidade.Logradouro = logradouro;

					return localidade;
				}
				else
				{
					return new Localidade();
				}
			}
			catch (Exception e)
			{
				return new Localidade();
			}	
		}

		[HttpGet("BuscaMunicipio")]
		public List<Localidade> BuscaMunicipio(string uf)
		{
			return localidadesLista.Select(x => x).Where(x => x.UnidadeFederativa == uf).OrderBy(x => x.Municipio).ToList();
		}

		[HttpGet("BuscaLogradouro")]
		public List<Logradouro> BuscaLogradouro(long codigoMunicipio)
		{
			return logradourosLista.Select(x => x).Where(x => x.CodigoMunicipio == codigoMunicipio).OrderBy(x => x.NomeLogradouro).ToList();
		}

		private List<Logradouro> CarregaLogradouros()
		{
			List<Logradouro> logradouroLista = new List<Logradouro>();

			if (System.IO.File.Exists(pathLogradouro))
			{
				using (StreamReader streamReader = new StreamReader(pathLogradouro, Encoding.Latin1))
				{
					string s;
					while ((s = streamReader.ReadLine()) != null)
					{
						var stringSeparada = s.Split('@');


						logradouroLista.Add(new Logradouro(
								long.Parse(stringSeparada[0]),
								long.Parse(stringSeparada[2]),
								stringSeparada[7],
								stringSeparada[10].Trim(),
								stringSeparada[5]
							));

					}
				}
			}

			return logradouroLista;
		}

		private List<Localidade> CarregaLocalizacoes()
		{
			List<Localidade> listaLocalidades = new List<Localidade>();

			if (System.IO.File.Exists(pathLocalizacao))
			{
				using (StreamReader streamReader = new StreamReader(pathLocalizacao, Encoding.Latin1))
				{
					string s;

					while ((s = streamReader.ReadLine()) != null)
					{
						var stringSeparada = s.Split('@');

						listaLocalidades.Add(new Localidade(
							long.Parse(string.IsNullOrEmpty(stringSeparada[0]) ? "0" : stringSeparada[0]),
							long.Parse(string.IsNullOrEmpty(stringSeparada[8]) ? "0" : stringSeparada[8]),
							stringSeparada[1],
							stringSeparada[2]
							));
					}
				}
			}

			return listaLocalidades;
		}
	}
}