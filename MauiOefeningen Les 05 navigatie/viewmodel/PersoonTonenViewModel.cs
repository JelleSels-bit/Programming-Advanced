using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
        [QueryProperty(nameof(Personen), "Personen")]
    public partial class PersoonTonenViewModel : BaseViewModel
    {

        [ObservableProperty]
        ObservableCollection<Persoon> personen ;

        [ObservableProperty]
        string uitvoer;

        public PersoonTonenViewModel()
        {
            Title = "Persoon Tonen";

            Debug.WriteLine("bbbbb");

            UpdateUitvoer();
        }


        partial void OnPersonenChanged(ObservableCollection<Persoon> value)
        {

            Debug.WriteLine("aaaaaaaa");
            


        }
        

        
        [RelayCommand]
        public void UpdateUitvoer()
        {

            if (Personen == null || Personen.Count == 0)
            {
                Uitvoer = "Geen personen beschikbaar.";
                return;
            }
            double totaleleeftijd = 0;
            int huidigjaar = DateTime.Today.Year;
            

            foreach (Persoon item in Personen)
            {
                int geboorteJaar = item.GeboorteDatum.Year;
                int leeftijd = huidigjaar - geboorteJaar;
                totaleleeftijd += leeftijd;
            }
            double resultaat = totaleleeftijd / Personen.Count;
            Uitvoer = $"Het aantal personen is {Personen.Count} en de gemiddelde leeftijd is {resultaat} ";
            OnPropertyChanged(nameof(Uitvoer)); 
        }

    }
}
