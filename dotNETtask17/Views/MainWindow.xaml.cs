using dotNETtask17.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNETtask17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookViewModel vm = new BookViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            vm.Add();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            (DataContext as BookViewModel).Save();
        }
    }
}
