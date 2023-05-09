using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfIocDemo.Services;

interface ICatFactsService
{
    Task<IEnumerable<string>> GetCatFactsAsync(int limit);
}
