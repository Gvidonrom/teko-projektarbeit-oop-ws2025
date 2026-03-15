using System.Windows;
using KnowledgeBase.WpfApp.ViewModels;

namespace KnowledgeBase.WpfApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}