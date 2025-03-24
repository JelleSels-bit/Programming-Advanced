using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.viewmodel
{
    [QueryProperty(nameof(Werknemer), "werknemer")]
    [QueryProperty(nameof(Functies), "Functies")]

    public partial class DetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        Werknemer werknemer;

        [ObservableProperty]
        ObservableCollection<Functie> functies;
        public DetailViewModel() 
        {
            Title = "DetailPagina";
        }
        partial void OnWerknemerChanged(Werknemer value)
        {
            Title = "Details " + Werknemer.VolledigeNaam;
        }
    }
}
