using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class VakViewModel : ObservableObject
    {
        [ObservableProperty]
        string voornaam, achternaam, lokaal, uitvoer,campus;

        [ObservableProperty]
        int score;

        [ObservableProperty]
        string datum;

        public VakViewModel()
        {
            Voornaam = string.Empty;
            Achternaam = string.Empty;
            Lokaal = string.Empty;
            Uitvoer = string.Empty;
            Campus = String.Empty;
            Score = 0;
            Datum = DateTime.Now.ToString("dd/MM/yy");
        }

        [RelayCommand]
        public void ResultaatTonen()
        {
            Uitvoer = $"Welkom {Voornaam} {Achternaam}\n" +
                   $"Je vast lokaal is {Lokaal} in {Campus}\n" +
                   $"Je eerste les is op {Datum}\n" +
                   $"Je hoopt een {Score}/20 te halen\n";
                
        }


    }
}
