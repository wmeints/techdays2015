using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Framework.ConfigurationModel;
using Newtonsoft.Json;

namespace MyMoney.Search.Services {
	public class ElasticSearchClient: ISearchClient {
		private HttpClient _client;
		private string _indexName;
		private string _typeName;
		
		public ElasticSearchClient(IConfiguration configuration) {
			_client = new HttpClient(new HttpClientHandler());
			_client.BaseAddress = new Uri(configuration.Get("elasticsearch:url"), UriKind.RelativeOrAbsolute);
			
			_indexName = configuration.Get("elasticsearch:index");
			_typeName = configuration.Get("elasticsearch:type");
		}
		
		public async Task<List<dynamic>> Find(string query) {
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, 
				"/" + _indexName + "/" + _typeName + "/_search");
				
			var searchQuery = new {
				query_string = new {
					default_field = "description",
					query = query
				}
			};
			
			request.Content = new StringContent(
				JsonConvert.SerializeObject(searchQuery), 
				Encoding.UTF8, "application/json");
				
			var response = await _client.SendAsync(request);
			var responseText = await response.Content.ReadAsStringAsync();
			
			return JsonConvert.DeserializeObject<List<dynamic>>(responseText);
		}
	}
}