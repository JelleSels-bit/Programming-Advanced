using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;


namespace MauiOefeningen.viewmodel
{
    public partial class WerknemerViewModel : BaseViewModel
    {
        //Stap 1 maak het viewmodel
        [ObservableProperty]
        Werknemer werknemer;

        [ObservableProperty]
        ObservableCollection<Werknemer> werknemers;

        [ObservableProperty]
        List<string> functies;
        public WerknemerViewModel()
        {
            Title = "Lijst van werknemers";
            Werknemer = new Werknemer();
            Werknemers = [];
            Functies = ["Manager","Dev","Designer"];
        }

        



        [RelayCommand]
        public void WerknemerToevoegen()
        {
            Werknemers.Add(Werknemer);
        }

    }
}
