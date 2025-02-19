using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class FactuurViewModel : BaseViewModel
    {
        [ObservableProperty]
        Product product;

        [ObservableProperty]
        int totaal, subTotaal, eindTotaal,btw;

        [ObservableProperty]
        ObservableCollection<Product> producten;

        public FactuurViewModel()
        {
            Product = new Product();
            Totaal = 0;
            SubTotaal = 0;
            EindTotaal = 0;
            producten = [];
        }

        [RelayCommand]
        public void ProductToevoegen()
        {

        }


    }
}
