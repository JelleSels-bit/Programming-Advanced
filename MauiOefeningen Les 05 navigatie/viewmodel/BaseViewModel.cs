using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [RelayCommand]
        public static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        public async void GoToHome()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
