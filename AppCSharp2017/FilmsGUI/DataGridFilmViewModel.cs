using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FilmsBLL;
using FilmsDTO;
#pragma warning disable IDE1006
namespace FilmsGUI
{
    class DataGridFilmViewModel : INotifyPropertyChanged
    {
        public List<FilmDTO> dtolist { get; set; }
        public FilmsBLLManager dc { get; set; }

        public ButtonCommand commandNext { get; set; }
        public ButtonCommand commandPrec { get; set; }

        public static int offset = 0;
        public static int nbr = 20;

        public DataGridFilmViewModel()
        {
            dc = new FilmsBLLManager();
            dtolist = dc.getFilmList(0,nbr);
            commandNext = new ButtonCommand(Next, CanDoNext, this);
            commandPrec = new ButtonCommand(Prec, CanDoPrec, this);
        }

        public bool CanDoPrec()
        {
            return offset >= nbr ? true: false;
        }

        public bool CanDoNext()
        {
            return true;
            return (offset < dc.CountFilm());
        }

        public void Prec()
        {
            if (offset - nbr < 0)
            {
                MessageBox.Show("Pas de films disponibles", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            offset = offset - nbr;
            dtolist = dc.getFilmList(offset, nbr);
            if (dtolist.Count == 0)
            {
                MessageBox.Show("Fin des résultats", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("dtolist"));
        }

        public void Next()
        {
            dtolist = dc.getFilmList(offset, nbr);
            if (dtolist.Count == 0)
            {
                MessageBox.Show("Fin des résultats", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            offset = offset + nbr;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("dtolist"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
#pragma warning restore IDE1006