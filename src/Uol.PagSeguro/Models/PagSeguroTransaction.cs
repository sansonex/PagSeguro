using System.Xml.Serialization;

namespace Uol.PagSeguro
{
	public class PagSeguroTransaction
	{
		[XmlElement(ElementName = "date")] public string Date { get; set; }

		[XmlElement(ElementName = "code")] public string Code { get; set; }


		[XmlElement(ElementName = "reference")]
		public string Reference { get; set; }

		[XmlElement(ElementName = "status")] public string Status { get; set; }

		[XmlElement(ElementName = "paymentMethod")]
		public PagSeguroPaymentMethod PaymentMethod { get; set; }

		[XmlElement(ElementName = "grossAmount")]
		public string GrossAmount { get; set; }
	}
}