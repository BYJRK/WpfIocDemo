using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfIocDemo.Services;

class CatFactsService : ICatFactsService
{
    private readonly IWebClient _webClient;

    public CatFactsService(IWebClient webClient)
    {
        this._webClient = webClient;
    }

    public async Task<IEnumerable<string>> GetCatFactsAsync(int limit)
    {
        var url = $"https://catfact.ninja/facts?limit={limit}";

        var response = await _webClient.GetStringAsync(url);

        var data = JObject.Parse(response);

        return data["data"].Select(x => x["fact"].ToString());
    }
}
