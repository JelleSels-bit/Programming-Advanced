using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class VragenlijstViewModel : ObservableObject
    {
        [ObservableProperty]
        string antwoordEten, antwoordDrinken,naam,uitkomst,eten,drinken,sporten;

        [ObservableProperty]
        bool isVisibleStackLayout;

        [ObservableProperty]
        int slider,score;
        
       

        public VragenlijstViewModel()
        {
            Naam = string.Empty;
            IsVisibleStackLayout = false;
            PopUp();
            AntwoordEten = string.Empty;
            AntwoordDrinken = string.Empty;
            Uitkomst = string.Empty;
            Score = 0;
            Eten = string.Empty;
            Drinken = string.Empty;
            Sporten = string.Empty;
    
        }
    [RelayCommand]
        public async void PopUp()
        {
            while (string.IsNullOrWhiteSpace(Naam))
            {
                Naam = await Shell.Current.DisplayPromptAsync("Naam ingeven", "Geef je naam ");
                if (string.IsNullOrWhiteSpace(Naam))
                {
                    await Shell.Current.DisplayAlert("Fout", "Je moet verplicht een naam ingeven", "OK");
                }
            }
            IsVisibleStackLayout = true;
        }
        [RelayCommand]
        public async void Controleren()
        {
            if (string.IsNullOrWhiteSpace(AntwoordDrinken) || string.IsNullOrWhiteSpace(antwoordEten))
            {
                await Shell.Current.DisplayAlert("Fout", "Maak een keuze bij alle vragen", "OK");
            }
            
            if (AntwoordEten.ToLower() == "ja")
            {
                Eten = "voldoende";
                Score++;
            }
            else
            {
                Eten = "onvoldoende";
            }
            
            if (AntwoordDrinken.ToLower() == "ja")
            {
                Drinken = "voldoende";
                Score++;
            }else
            {
                Drinken = "Onvoldoende";
            }
            if (slider >= 3)
            {
                Sporten = "Voldoende";
                Score++;
            }
            else
            {
                Sporten = "Onvoldoende";
            }

            if (Score == 3)
            {
                uitkomst = $"Je eet {Eten}, je drinkt {Drinken},je sport {Sporten}. Je bent in topvorm {Naam}";
            }
            else
            {
                uitkomst = $"Je eet {Eten}, je drinkt {Drinken},je sport {Sporten}. Eten,Drinke & sporten is belangrijk {Naam}";
            }



        }



    }




}

