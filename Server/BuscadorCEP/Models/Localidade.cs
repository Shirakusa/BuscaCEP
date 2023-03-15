namespace BuscadorCEP.Models
{
	public class Localidade
	{
		public long CodigoMunicipio { get; set; }
		public long CodigoIbge { get; set; }
		public string UnidadeFederativa { get; set; }
		public string Municipio { get; set; }
		public Logradouro Logradouro { get; set; }

		public Localidade()
		{
		}

		public Localidade(long codigoMunicipio, long codigoIbge, string unidadeFederativa, string municipio)
		{
			CodigoMunicipio = codigoMunicipio;
			CodigoIbge = codigoIbge;
			UnidadeFederativa = unidadeFederativa;
			Municipio = municipio;
		}

		public override bool Equals(object? obj)
		{
			return obj is Localidade localidade &&
				   CodigoMunicipio == localidade.CodigoMunicipio &&
				   CodigoIbge == localidade.CodigoIbge &&
				   UnidadeFederativa == localidade.UnidadeFederativa &&
				   Municipio == localidade.Municipio &&
				   EqualityComparer<Logradouro>.Default.Equals(Logradouro, localidade.Logradouro);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(CodigoMunicipio, CodigoIbge, UnidadeFederativa, Municipio, Logradouro);
		}
	}
}
