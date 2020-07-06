using System;
using Microsoft.Extensions.DependencyInjection;
using Uol.PagSeguro.Interfaces;
using Uol.PagSeguro.Services;
using Uol.PagSeguro.Settings;

namespace Uol.PagSeguro
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPagSeguro(this IServiceCollection services, PagSeguroSettings settings)
		{
			services.AddSingleton(settings);

			services.AddScoped<IPagSeguroBoletoService, PagSeguroBoletoService>();

			services.AddHttpClient<PagSeguroClient>(opt =>
			{
				opt.Timeout = TimeSpan.FromMinutes(settings.RequestTimeOut);
			});

			return services;
		}
	}
}