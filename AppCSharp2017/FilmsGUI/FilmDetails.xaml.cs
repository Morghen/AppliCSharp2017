using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FilmsBLL;
using FilmsDTO;
using SmartWCFService;

namespace FilmsGUI
{
    /// <summary>
    /// Interaction logic for FilmDetails.xaml
    /// </summary>
    public partial class FilmDetails : Window
    {
        public SmartWcf ser = new SmartWcf();
        public FilmDetails(FilmDTO tmp)
        {
            InitializeComponent();
            DataContext = tmp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ser== null)
                return;
            ser.UpdateFilm((int) IdLabel.Content, UrlLabel.Text);
            DataContext = ser.RefreshFilm((int) IdLabel.Content);
        }
    }
}
