namespace Uol.PagSeguro.Models
{
	public class PagSeguroBoleto
	{
		public string Barcode { get; set; }
		public string Code { get; set; }

		public string DueDate { get; set; }

		public string PaymentLink { get; set; }
	}
}