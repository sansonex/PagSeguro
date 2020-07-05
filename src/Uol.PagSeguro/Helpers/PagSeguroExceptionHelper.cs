using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Uol.PagSeguro.Extensions;

namespace Uol.PagSeguro.Helpers
{
	public static class PagSeguroExceptionHelper
	{
		public static async Task<List<Error>> HandlePagSeguroInvalidRequest(HttpResponseMessage response)
		{
			var errors = new List<Error>();

			var content = await response.Content.ReadAsJsonAsync<ResponseError>();

			if (content?.Errors == null || content.Errors?.Count == 0)
			{
				errors.Add(new Error() { Code = 0, Message = "unknown error" });
				return errors;
			}

			errors.AddRange(content.Errors);

			return errors;
		}
	}
}