using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class NamenViewModel : BaseViewModel
    {
        [ObservableProperty]
        string naam;


        [ObservableProperty]
        ObservableCollection<String> namen;

        public NamenViewModel() 
        {
            Naam = string.Empty;
            Namen = [];
            Title = "Namen tonen";
        }

        [RelayCommand]
        public void NaamToevoegen()
        {
            Namen.Add(Naam);
            Naam = string.Empty;
        }


    }
}
