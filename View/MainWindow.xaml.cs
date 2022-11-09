using _7DE_Prazdnikova.View;
using _7DE_Prazdnikova.ViewModels;
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

namespace _7DE_Prazdnikova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel? viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowViewModel)DataContext;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(viewModel != null)
                viewModel.Search(TextBox1.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow window = new AgentsWindow();
            window.ShowDialog();
        }
    }
}
