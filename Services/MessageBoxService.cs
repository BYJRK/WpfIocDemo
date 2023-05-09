using System.Windows;

namespace WpfIocDemo.Services;

internal class MessageBoxService : IMessageBoxService
{
    public void ShowMessage(string message)
    {
        MessageBox.Show(message);
    }
}
