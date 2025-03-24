using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiOefeningen.viewmodel
{
    public partial class PersoonViewModel : ObservableObject
    {
        [ObservableProperty]
        string naam;

        partial void OnNaamChanged(string value)
        {
            Shell.Current.DisplayAlert("Name Changed",naam,"ok");
        }

        partial void OnNaamChanging(string value)
        {
            Shell.Current.DisplayAlert("Name Chaning", naam, "ok");
        }
                  
        
        //private string _naam;

        //public string Naam
        //{
        //    //Geeft de huidige waarde van _naam terug
        //    get { return _naam; }
        //    set
        //    {
        //        //Als de waarde verandert, wijzigt _naam naar de nieuwe waarde.
        //        if (_naam != value)
        //        {
        //            _naam = value;
        //            OnPropertyChanged(nameof(Naam));
        //        }
        //    }
        //}

        ////Wanneer een eigenschap van een object wordt gewijzigd, wordt deze gebeurtenis PropertyChanged geactiveerd om aan te geven dat de waarde van die eigenschap is gewijzigd en dat iets anders, zoals de gebruikersinterface, mogelijk moet reageren op die wijziging.
        //public event PropertyChangedEventHandler PropertyChanged;

        ////Dit is een beschermde (protected) methode genaamd OnPropertyChanged, die verantwoordelijk is voor het aanroepen van de PropertyChanged-gebeurtenis wanneer een eigenschap is gewijzigd. De methode accepteert een propertyName als parameter, wat de naam is van de eigenschap die is gewijzigd.
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
