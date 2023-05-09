using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Serilog;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfIocDemo.Services;

namespace WpfIocDemo;

partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    string title = "CatFacts";

    private ILogger _logger;
    private readonly ICatFactsService _catFactsService;
    private readonly IMessageBoxService _messageBoxService;

    public ObservableCollection<string> CatFacts { get; } = new();

    public MainWindowViewModel(ILogger logger, ICatFactsService catFactsService, IMessageBoxService messageBoxService)
    {
        _logger = logger;
        this._catFactsService = catFactsService;
        this._messageBoxService = messageBoxService;
        _logger.Information("ViewModel Loaded.");
    }

    [RelayCommand]
    async Task GetFacts(string text)
    {
        if (int.TryParse(text, out var limit))
        {
            if (limit <= 0)
            {
                _messageBoxService.ShowMessage("输入的 limit 值应该大于 0！");
                return;
            }
            var facts = await _catFactsService.GetCatFactsAsync(limit);
            foreach (var fact in facts)
            {
                CatFacts.Add(fact);
            }
        }
        else
        {
            _messageBoxService.ShowMessage("输入的 limit 值不对！");
        }
    }
}
