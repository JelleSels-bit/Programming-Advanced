using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class PersonenIngevenViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Persoon> personen;

        [ObservableProperty]
        Persoon persoon;

        public PersonenIngevenViewModel()
        {
            Title = "Personen ingeven";
            Persoon = new Persoon();
            Personen = [];
        }

        [RelayCommand]
        public void Ingeven()
        {
            if (!string.IsNullOrWhiteSpace(Persoon.Voornaam) && !Personen.Contains(Persoon))
            {
                Personen.Add(Persoon);
                Persoon = new();
            }
        }

        [RelayCommand]
        public async Task GoToPersonenTonen()
        {
            if (Personen == null) return;   
            
            await Shell.Current.GoToAsync(nameof(PersonenTonenPage), true, new Dictionary<string, object>
            {
               
                { "Personen", Personen}
            });
        }
    }
}
