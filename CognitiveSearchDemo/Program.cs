using CognitiveSearchDemo.Model;
using Azure;
using Azure.Search.Documents;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

IConfigurationSection section = configuration.GetSection("CognitiveSearch");

string AZURE_COGNITIVE_SEARCH_KEY = section["AZURE_COGNITIVE_SEARCH_KEY"];
string AZURE_COGNITIVE_SEARCH_NAME = section["AZURE_COGNITIVE_SEARCH_NAME"];
string AZURE_COGNITIVE_SEARCH_INDEX = section["AZURE_COGNITIVE_SEARCH_INDEX"];

string searchServiceEndPoint = $"https://{AZURE_COGNITIVE_SEARCH_NAME}.search.windows.net";
string queryApiKey = AZURE_COGNITIVE_SEARCH_KEY;

SearchClient searchClient = new SearchClient(new Uri(searchServiceEndPoint), AZURE_COGNITIVE_SEARCH_INDEX, new AzureKeyCredential(queryApiKey));
SearchOptions options = new SearchOptions()
{
    Size = 5
};
var response = await searchClient.SearchAsync<SearchModel>("Face AI", options);
var resString = response.GetRawResponse().Content.ToString();

var value = JsonSerializer.Deserialize<SearchModel>(resString).Value;

List<SearchValueModel> searchResults = new List<SearchValueModel>();
foreach (var item in value.RootElement.EnumerateArray())
{
    var searchResult = JsonSerializer.Deserialize<SearchValueModel>(item.ToString());
    searchResults.Add(searchResult);
}
