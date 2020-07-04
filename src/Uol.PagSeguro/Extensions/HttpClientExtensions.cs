using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uol.PagSeguro.Extensions
{
	public static class HttpClientExtensions
	{
		public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
			this HttpClient httpClient,
			string url,
			T data,
			string encoding,
			Dictionary<string, string> queryString)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			foreach (var item in queryString) query[item.Key] = item.Value;

			var serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};

			var dataAsString = JsonConvert.SerializeObject(data, serializerSettings);

			var content = new StringContent(dataAsString, Encoding.GetEncoding(encoding));

			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			return httpClient.PostAsync($"{url}?{query}", content);
		}

		public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
		{
			var stream = await content.ReadAsStreamAsync();

			using (var streamReader = new StreamReader(stream))
			{
				using (var jsonTextReader = new JsonTextReader(streamReader))
				{
					var jsonSerializer = new JsonSerializer();
					return jsonSerializer.Deserialize<T>(jsonTextReader);
				}
			}
		}
	}
}