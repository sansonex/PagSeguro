using System.Xml.Serialization;

namespace Uol.PagSeguro.Models
{
	public class PagSeguroPaymentMethod
	{
		[XmlElement(ElementName = "type")] public string Type { get; set; }
		[XmlElement(ElementName = "code")] public string Code { get; set; }
	}
}