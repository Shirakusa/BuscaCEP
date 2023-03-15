namespace BuscadorCEP.Models
{
	public class Logradouro
	{
		public long CodigoMunicipio { get; set; }
		public long CodigoLogradouro { get; set; }
		public string NomeLogradouro { get; set; }
		public string Cep { get; set; }
		public string Endereco { get; set; }

		public Logradouro()
		{
		}

		public Logradouro(long codigoLogradouro, long codigoMunicipio, string cep, string endereco, string logradouro)
		{
			CodigoLogradouro = codigoLogradouro;
			CodigoMunicipio = codigoMunicipio;
			Cep = cep;
			Endereco = endereco;
			NomeLogradouro = logradouro;
		}

		public override bool Equals(object? obj)
		{
			return obj is Logradouro logradouro &&
				   CodigoMunicipio == logradouro.CodigoMunicipio &&
				   CodigoLogradouro == logradouro.CodigoLogradouro &&
				   NomeLogradouro == logradouro.NomeLogradouro &&
				   Cep == logradouro.Cep &&
				   Endereco == logradouro.Endereco;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(CodigoMunicipio, CodigoLogradouro, NomeLogradouro, Cep, Endereco);
		}
	}
}
