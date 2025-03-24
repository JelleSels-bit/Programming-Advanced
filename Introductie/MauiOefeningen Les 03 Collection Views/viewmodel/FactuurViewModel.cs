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
        double subTotaal, eindTotaal,btw;

        


        [ObservableProperty]
        ObservableCollection<Product> producten;

        public FactuurViewModel()
        {
            Product = new Product();
            SubTotaal = 0;
            EindTotaal = 0;
            Btw = 0;
            Producten = [];
            Title = "Factuur";
        }

        [RelayCommand]
        public void ProductToevoegen()
        {
            Product.Totaal = Product.Aantal * Product.Prijs;
            Producten.Add(Product);


            SubTotaal = 0;
            foreach (Product item in producten)
            {
                SubTotaal += item.Totaal;
            }

            SubTotaal = Math.Round(SubTotaal, 2);

            Btw = Math.Round(SubTotaal * 0.21,2);
            EindTotaal = Math.Round(SubTotaal + Btw,2);

            Product = new Product();

        }


    }
}
