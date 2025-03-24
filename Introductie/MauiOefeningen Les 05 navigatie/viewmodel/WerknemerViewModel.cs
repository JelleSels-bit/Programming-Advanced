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
        List<Functie> functies;

        private readonly IWerknemerRepository _werknemerrepository;
        private readonly IFunctieRepository _functierepository;

        public WerknemerViewModel(IWerknemerRepository werknemerRepository, IFunctieRepository functieRepository)
        {
            Title = "Lijst van werknemers";
            _werknemerrepository = werknemerRepository;
            _functierepository = functieRepository;
            Werknemer = new Werknemer();
            Werknemers = new ObservableCollection<Werknemer>(_werknemerrepository.GetWerknemers());
            Functies = new List<Functie>(_functierepository.GetFuncties());

        }

        



        [RelayCommand]
        public void WerknemerToevoegen()
        {
            Werknemers.Add(Werknemer);
        }

        [RelayCommand]
        public async void GoToDetails()
        {
            if (Werknemer.Achternaam != null)
            {
                
            //nameof garandeerd dat de naam van de pagina juist is
            //new Dictionart maakt een bibliotheek van objecten die we meegeven naar de volgende pagina.
            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                { "Werknemer", Werknemer},
                { "Functies", Functies }
            });
            }



        }

        [RelayCommand]
        public void VerwijderWerknemer()
        {
            Werknemers.Remove(Werknemer);
        }

    }
}
