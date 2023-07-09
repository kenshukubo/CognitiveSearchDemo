using CognitiveSearchDemo.Model;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using Azure.Core.Serialization;

string AZURE_COGNITIVE_SEARCH_KEY = "9dPsjVwi6TuEFjw1bZ19O4cDpKzIZi5SkwujGZWm9bAzSeD6CW4z";
string AZURE_COGNITIVE_SEARCH_NAME = "cogsearch-searchdocs-dev-001";
string AZURE_COGNITIVE_SEARCH_INDEX = "azureblob-index";

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
