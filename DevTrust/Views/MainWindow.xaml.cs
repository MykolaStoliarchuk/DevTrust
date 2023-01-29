using DevTrust.Data;
using DevTrust.Models;
using DevTrust.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;


namespace DevTrust
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new FakeUser());          
        }
    }
}
