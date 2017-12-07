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
using FilmsGUI.ServiceReference;
using SmartWCFService;

#pragma warning disable IDE1006
namespace FilmsGUI
{
    class DataGridFilmViewModel : INotifyPropertyChanged
    {
        //SmartWcf ser = new SmartWcf();
        ServiceReference.SmartWcfClient cli = new SmartWcfClient();
        public List<FilmDTO> dtolist { get; set; }

        public ButtonCommand commandNext { get; set; }
        public ButtonCommand commandPrec { get; set; }

        public FilmDTO Movie { get; set; }

        public static int offset = 0;
        public static int nbr = 20;

        public DataGridFilmViewModel()
        {
            //dtolist = ser.getFilmList(0,nbr);
            dtolist = new List<FilmDTO>(cli.getFilmList(0, nbr));
            commandNext = new ButtonCommand(Next, CanDoNext, this);
            commandPrec = new ButtonCommand(Prec, CanDoPrec, this);
        }

        public bool Refresh()
        {
            //dtolist = ser.getFilmList(0, nbr);
            dtolist = new List<FilmDTO>(cli.getFilmList(offset, nbr));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("dtolist"));
            return true;
        }

        public bool CanDoPrec()
        {
            return offset >= nbr ? true: false;
        }

        public bool CanDoNext()
        {
            //return true;
            //return (offset < ser.CountFilm());
            return (offset < cli.CountFilm());
        }

        public void Prec()
        {
            offset = offset - nbr;
            dtolist = null;
            //dtolist = ser.getFilmList(offset, nbr);
            dtolist = new List<FilmDTO>(cli.getFilmList(offset, nbr));
            if (dtolist.Count == 0)
            {
                MessageBox.Show("Fin des résultats", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("dtolist"));
        }

        public void Next()
        {
            dtolist = null;
            //dtolist = ser.getFilmList(offset, nbr);
            offset = offset + nbr;
            dtolist = new List<FilmDTO>(cli.getFilmList(offset, nbr));
            if (dtolist.Count == 0)
            {
                MessageBox.Show("Fin des résultats", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("dtolist"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
#pragma warning restore IDE1006