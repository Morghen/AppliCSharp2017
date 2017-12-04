using FilmsBLL;
using FilmsDTO;
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
using SmartWCFService;

namespace FilmsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainGrid.SelectedIndex >= 0)
            {
                FilmDetails fd = new FilmDetails();
                //fd.fb = (FilmsBLLManager)DataContext.GetType().GetProperty("dc").GetValue(DataContext);
                fd.DataContext =((List<FilmDTO>) DataContext.GetType().GetProperty("dtolist").GetValue(DataContext))[MainGrid.SelectedIndex];
                fd.ShowDialog();
                ((DataGridFilmViewModel) DataContext).Refresh();
            }
        }
    }
}
