using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    [QueryProperty(nameof(Personen), "Personen")]
    public partial class PersoonTonenViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Persoon> personen;

        [ObservableProperty]
        private string uitvoer;

        public PersoonTonenViewModel()
        {
            Title = "Persoon Tonen";
        }

        // Zorg ervoor dat we de uitvoer bijwerken wanneer Personen wordt gewijzigd
        partial void OnPersonenChanged(ObservableCollection<Persoon> value)
        {
            Debug.WriteLine($"Nieuwe lijst ontvangen met {value?.Count ?? 0} personen.");
            UpdateUitvoer();
        }

        [RelayCommand]
        public void UpdateUitvoer()
        {
            if (Personen == null || Personen.Count == 0)
            {
                Uitvoer = "Geen personen beschikbaar.";
                return;
            }

            double totaleLeeftijd = 0;
            int huidigJaar = DateTime.Today.Year;

            foreach (Persoon item in Personen)
            {
                if (item.GeboorteDatum == DateTime.MinValue) continue; // Vermijd ongeldige datums

                int geboorteJaar = item.GeboorteDatum.Year;
                int leeftijd = huidigJaar - geboorteJaar;
                totaleLeeftijd += leeftijd;
            }

            double resultaat = totaleLeeftijd / Personen.Count;
            Uitvoer = $"Het aantal personen is {Personen.Count} en de gemiddelde leeftijd is {resultaat:F1} jaar.";
        }
    }
}
