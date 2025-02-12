using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class StackLayoutViewModel : ObservableObject
    {
        [ObservableProperty]
        string naam, emailAdres, telefoon, geslacht, uitvoer;

        public StackLayoutViewModel() 
        {
            Naam = string.Empty;
            EmailAdres = string.Empty;
            Telefoon = string.Empty;
            Geslacht = string.Empty;
            Uitvoer = string.Empty;
        }
        [RelayCommand]
        public void UitvoerTonen()
        {
            Uitvoer = $"Welkom {Naam}, We kunnen je bereiken op het emailadres {EmailAdres} & {Telefoon} u bent een {geslacht}";
        }
    }
}
