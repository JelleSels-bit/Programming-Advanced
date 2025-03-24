using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class NaamTonenViewModel : ObservableObject
    {
        [ObservableProperty]
        string naam,uitKomst;
        

        [ObservableProperty]
        int getal;

        public NaamTonenViewModel()
        {
            Naam = string.Empty;
            UitKomst= string.Empty;
            Getal = 0;
        }

        [RelayCommand]
        public void AantalKeer()
        {
            for (int i = 0; i <= Getal; i++)
            {
                UitKomst += $"{Naam}, ";
            }
        }

        [RelayCommand]
        public void Leegmaken()
        {
            UitKomst = "";
        }
    }
}
