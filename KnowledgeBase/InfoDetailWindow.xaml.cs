using System.Diagnostics;
using System.Windows;

namespace KnowledgeBase.WpfApp;

public partial class InfoDetailWindow : Window
{
    private readonly string _url;

    public InfoDetailWindow(string contentOrUrl, string kind)
    {
        InitializeComponent();
        _url = contentOrUrl ?? string.Empty;

        if (kind == "Text")
        {
            HeaderText.Text = "Textinhalt:";
            ContentText.Text = contentOrUrl ?? string.Empty;
            UrlPanel.Visibility = Visibility.Collapsed;
        }
        else
        {
            HeaderText.Text = kind == "Image" ? "Bild-URL:" : "Dokument-URL:";
            ContentText.Text = contentOrUrl ?? string.Empty;
            UrlPanel.Visibility = Visibility.Visible;
        }
    }

    private void OpenLinkButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_url)) return;

        try
        {
            Process.Start(new ProcessStartInfo(_url) { UseShellExecute = true });
        }
        catch
        {
            MessageBox.Show("Link konnte nicht geöffnet werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
