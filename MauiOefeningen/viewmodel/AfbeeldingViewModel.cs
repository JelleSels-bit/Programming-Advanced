using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class AfbeeldingViewModel : ObservableObject
    {
        [ObservableProperty]
        int getal;

        [ObservableProperty]
        string afbeelding;

        public AfbeeldingViewModel() 
        {
            Getal = 1;
            Afbeelding = string.Empty;
        }

        [RelayCommand]
        public void AfbeeldingChanger()
        {
            Afbeelding = $"landschap{Getal}.jpg";


        }
    }
}
