using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.viewmodel
{
    [QueryProperty(nameof(Getal1), "Getal 1")]
    [QueryProperty(nameof(Getal2), "Getal 2")]
   

    public partial class GetallenDoorGeven2ViewModel : BaseViewModel
    {
        [ObservableProperty]
        int getal1;

        [ObservableProperty]
        int getal2;

        [ObservableProperty]
        string uitvoer;

        public GetallenDoorGeven2ViewModel()
        {
            Title = "GetallenDoorgeven2";
            

        }

        partial void OnGetal2Changed(int value)
        {
            if (Getal1 > Getal2)
            {
                Uitvoer = $"{Getal1} is groter dan {Getal2} ";
            }
            else
            {
                Uitvoer = $"{Getal2} is groter dan {Getal1} ";
            }
        }





    }
}
