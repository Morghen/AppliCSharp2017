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

namespace FilmsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<FilmDTO> dtolist;
        public List<String> res;
        public FilmsBLLManager dc;
        public static int offset = 0;
        public static int nbr = 50;

        public class DataItem
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string OriginalTitle { get; set; }
            public string Runtime { get; set; }

            public DataItem()
            { }
        }

        public MainWindow()
        {
            InitializeComponent();
            buttonSuiv.Click += ButtonSuiv_Click;
            buttonPrec.Click += ButtonPrec_Click;
            Init();
        }

        private void ButtonPrec_Click(object sender, RoutedEventArgs e)
        {
            Prec();
        }

        public void Init()
        {
            dc = new FilmsBLLManager();
            dtolist = null;
            res = null;
            Next();
        }

        public void Prec()
        {
            if (offset - 50 < 0)
            {
                MessageBox.Show("Pas de films disponibles", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainGrid.Items.Clear();
            offset = offset - 50;
            dtolist = dc.getFilmList(offset, nbr);
            if (dtolist.Count == 0)
            {
                MessageBox.Show("Fin des résultats", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (FilmDTO obj in dtolist)
            {
                res = dc.getFilmInfos(obj);
                MainGrid.Items.Add(new DataItem { Id = res[0], Title = res[1], OriginalTitle = res[2], Runtime = res[3] });
            }
        }

        public void Next()
        {
            dtolist = dc.getFilmList(offset, nbr);
            if(dtolist.Count == 0)
            {
                MessageBox.Show("Fin des résultats", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainGrid.Items.Clear();
            offset = offset + 50;
            foreach (FilmDTO obj in dtolist)
            {
                res = dc.getFilmInfos(obj);
                MainGrid.Items.Add(new DataItem { Id = res[0], Title = res[1], OriginalTitle = res[2], Runtime = res[3] });
            }
            
        }

        private void ButtonSuiv_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }
    }
}
