using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Uol.PagSeguro.Exceptions;
using Uol.PagSeguro.Extensions;
using Uol.PagSeguro.Helpers;
using Uol.PagSeguro.Settings;

namespace Uol.PagSeguro.Services
{
	public class BoletoService : IBoletoService
	{
		private readonly HttpClient _client;
		private PagSeguroSettings _settings;
		private ILogger _logger;

		public BoletoService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory, PagSeguroSettings settings)
		{
			_client = httpClientFactory.CreateClient(nameof(PagSeguroClient));
			_settings = settings;
			_logger = loggerFactory.CreateLogger<PagSeguroClient>();
		}

		public async Task<PagSeguroBoletoResponse> CreateBoletoAsync(PagSeguroBoletoRequest request)
		{
			try
			{
				_logger.LogInformation($"Creating Boleto - {request.Reference}");

				var queryString = new Dictionary<string, string>
				{
					{nameof(_settings.Email).ToLower(),_settings.Email}, {nameof(_settings.Token).ToLower(),_settings.Token}
				};

				using var response = await _client.PostAsJsonAsync(_settings.BoletoRequestUrl,
																   request,
																   _settings.Encoding,
																   queryString);

				if (!response.IsSuccessStatusCode)
					throw new PagSeguroException(response.StatusCode, await PagSeguroExceptionHelper.HandlePagSeguroInvalidRequest(response));

				var result = await response.Content.ReadAsJsonAsync<PagSeguroBoletoResponse>();

				return result;
			}
			catch (PagSeguroException e)
			{
				_logger.LogError($"Failed to create boleto {request.Reference}", e);
				throw e;
			}
		}
	}

	public interface IBoletoService
	{
		Task<PagSeguroBoletoResponse> CreateBoletoAsync(PagSeguroBoletoRequest request);
	}
}