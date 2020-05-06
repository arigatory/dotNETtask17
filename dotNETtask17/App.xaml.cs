using dotNETtask17.DataAccessLayer;
using dotNETtask17.Models;
using dotNETtask17.ViewModels;
using System.Windows;

namespace dotNETtask17
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            BookProvider provider = new BookProvider("Books.xml");
            BookModel model = new BookModel(provider);
            BookViewModel vm = new BookViewModel(model);
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = vm;
            MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
