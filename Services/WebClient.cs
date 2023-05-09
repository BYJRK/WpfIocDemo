using System.Net.Http;
using System.Threading.Tasks;

namespace WpfIocDemo.Services;

class WebClient : IWebClient
{
    private HttpClient httpClient = new();

    public async Task<string> GetStringAsync(string url)
    {
        return await httpClient.GetStringAsync(url);
    }
}
