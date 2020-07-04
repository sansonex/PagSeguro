namespace Uol.PagSeguro.Settings
{
	public class PagSeguroSettings
	{
		public string Email { get; set; }

		public string Token { get; set; }

		public string BoletoRequestUrl { get; set; }

		public string Encoding { get; set; } = "ISO-8859-1";

		/// <summary>
		/// In Minutes
		/// </summary>
		public int RequestTimeOut { get; set; } = 1;
	}
}