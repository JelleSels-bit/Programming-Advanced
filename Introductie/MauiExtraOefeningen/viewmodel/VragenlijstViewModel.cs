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
        string antwoordEten, antwoordDrinken,naam,uitkomst,eten;

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
            if (string.IsNullOrWhiteSpace(AntwoordDrinken) || string.IsNullOrWhiteSpace(AntwoordEten))
            {
                await Shell.Current.DisplayAlert("Fout", "Maak een keuze bij alle vragen", "OK");
            }

            Score = 0;

            if (AntwoordEten == "Ja") Score++;
            if (AntwoordDrinken == "Ja") Score++;
            if (Slider >= 3) Score++;

      
            if (Score == 3)
            {
                Uitkomst = $"Super bezig {Naam}, Je leeft heel gezond!";
            }
            else if (Score == 2)
            {
                Uitkomst = $"Goed bezig {Naam}, maar er is ruimte voor verbetering!";
            }
            else
            {
                Uitkomst = $"Probeer gezonder te leven {Naam}. Jij kan dit!";
            }


        }

        [RelayCommand]
        public async void Herstarten()
        {
            Naam = string.Empty;
            Score = 0;
            AntwoordEten = string.Empty;
            AntwoordDrinken = string.Empty;
            Slider = 0;
            Uitkomst = string.Empty;
            IsVisibleStackLayout = false;
            
            Naam = await Shell.Current.DisplayPromptAsync("Naam ingeven", "Geef je naam ");
            IsVisibleStackLayout = true;

        }



    }




}

