using System.Threading.Tasks;

namespace WpfIocDemo.Services;

internal interface IWebClient
{
    Task<string> GetStringAsync(string url);
}
