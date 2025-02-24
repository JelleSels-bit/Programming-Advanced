using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class GetallenViewModel : BaseViewModel
    {
        [ObservableProperty]
        int invoer,kleinste,grootste;

        [ObservableProperty]
        ObservableCollection<int> getallen;

       
        public GetallenViewModel() 
        {
            Invoer = 0;
            Title = "GetallenRij";
            Getallen = [];
            Kleinste = 0;
            Grootste = 0;
           
        }

        [RelayCommand]
        public async void GetalToevoegen()
        {
            if (Invoer > 20)
            {
                await Shell.Current.DisplayAlert("Fout","De invoer mag niet hoger zijn dan 20","OK");
                    
            }
            else
            {
            Getallen.Add(Invoer);
            Kleinste = Getallen.Min();
            Grootste = Getallen.Max();
                
            }

            

        }
    }
}
