using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.viewmodel
{
        [QueryProperty(nameof(Personen), "Personen")]
    public partial class PersoonTonenViewModel : BaseViewModel
    {

        [ObservableProperty]
        ObservableCollection<Persoon> personen;

        public PersoonTonenViewModel()
        {
            Title = "Persoon Tonen";
        }
    }
}
