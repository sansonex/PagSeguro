namespace Uol.PagSeguro.Models
{
	public class PagSeguroCustomer
	{
		public PagSeguroDocument Document { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public PagSeguroPhone Phone { get; set; }
	}
}