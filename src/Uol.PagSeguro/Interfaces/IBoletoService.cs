using System.Threading.Tasks;
using Uol.PagSeguro.Models;

namespace Uol.PagSeguro.Interfaces
{
	public interface IBoletoService
	{
		Task<PagSeguroBoletoResponse> CreateBoletoAsync(PagSeguroBoletoRequest request);
	}
}