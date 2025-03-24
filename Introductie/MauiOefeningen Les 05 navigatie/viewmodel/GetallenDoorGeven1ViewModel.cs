using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class GetallenDoorGeven1ViewModel : BaseViewModel
    {
        [ObservableProperty]
        int getal1;

        [ObservableProperty]
        int getal2;

        public GetallenDoorGeven1ViewModel()
        {
            Title = "GetallenDoorgeven1";
            Getal1 = 0;
            Getal2 = 0;

        }

        [RelayCommand]
        public async Task GeefGetalDoor()
        {
            if (Getal1 != 0 && Getal2 != 0)
            {
                await Shell.Current.GoToAsync(nameof(GetallenDoorgeven2Page), true, new Dictionary<string, object>()
                {
                    {"Getal 1", Getal1 },
                    { "Getal 2", Getal2}
                });
            }
        }
    }
}
