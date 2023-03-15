global using NUnit.Framework;
using BuscadorCEP.Controllers;
using BuscadorCEP.Models;
using System.Runtime.ConstrainedExecution;

namespace BuscadorCEPTest
{
	public class Tests
	{
		private Dictionary<string, Localidade> entradaBuscaEndereco = new Dictionary<string, Localidade>() {
			{
				"88309350", new Localidade(){
					Logradouro = new Logradouro() {
						Cep = "88309350",
						CodigoLogradouro = 428130,
						CodigoMunicipio = 8507,
						Endereco = "R Cmte Germano Rauert",
						NomeLogradouro = "Comandante Germano Rauert"
						},
					CodigoIbge = 4208203,
					CodigoMunicipio = 8507,
					Municipio = "Itajaí",
					UnidadeFederativa = "SC"
				}
			},
			{
				"89023750", new Localidade(){
					Logradouro = new Logradouro() {
						Cep = "89023750",
						CodigoLogradouro = 419717,
						CodigoMunicipio = 8377,
						Endereco = "R Theodora Gebien",
						NomeLogradouro = "Theodora Gebien"
						},
					CodigoIbge = 4202404,
					CodigoMunicipio = 8377,
					Municipio = "Blumenau",
					UnidadeFederativa = "SC"
				}
			}
		};

		[TestCase("88309350")]
		[TestCase("89023750")]
		public void TesteBuscaEndereco(string cep)
		{
			//Arrange
			var saidaEsperada = entradaBuscaEndereco[cep];

			//Act
			var resultado = new EnderecoController().BuscaEndereco(cep);

			//Assert
			Assert.AreEqual(saidaEsperada, resultado);
		}

		[TestCase("SC", 8507, 428130)]
		public void TesteBuscaCep(string estado, long codigoMunicipio, long codigoLongradouro)
		{
			//Arrange
			Localidade saidaEsperada = new Localidade()
			{
				Logradouro = new Logradouro()
				{
					Cep = "88309350",
					CodigoLogradouro = 428130,
					CodigoMunicipio = 8507,
					Endereco = "R Cmte Germano Rauert",
					NomeLogradouro = "Comandante Germano Rauert"
				},
				CodigoIbge = 4208203,
				CodigoMunicipio = 8507,
				Municipio = "Itajaí",
				UnidadeFederativa = "SC"
			};

			//Act
			var resultado = new EnderecoController().BuscaCep(estado, codigoMunicipio, codigoLongradouro);

			//Assert
			Assert.AreEqual(saidaEsperada, resultado);
		}
	}
}