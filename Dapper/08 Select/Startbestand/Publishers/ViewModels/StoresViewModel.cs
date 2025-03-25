using Publishers.Data.Interface;
using Publishers.Models;

namespace Publishers.ViewModels
{
    public partial class StoresViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Store> stores;

        [ObservableProperty]
        Store store;


        [ObservableProperty]
        string naam = "";

        [ObservableProperty]
        string staat = "";

        [ObservableProperty]
        string id = "";

        private IStoresRepository _storesRepository;

        public StoresViewModel(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }


        [RelayCommand]
        public void OphalenWinkelsViaNaam()
        {
            IsBusy = true; 
            Stores = new ObservableCollection<Store>(_storesRepository.OphalenViaNaam(Naam));
            IsBusy = false;

        }

        [RelayCommand]
        public void OphalenWinkelsViaStaat()
        {
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storesRepository.OphalenViaStaat(Staat));
            IsBusy = false;

        }

        [RelayCommand]
        public void OphalenWinkelsViaStaatEnNaam()
        {
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storesRepository.OphalenViaStaatEnNaam(Naam,Staat));
            IsBusy = false;

        }

        [RelayCommand]
        public void OphalenWinkelViaId()
        {
            

            if (!int.TryParse(Id, out int id))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldig ID", "Sluiten");
            }
            IsBusy = true;
            Store = _storesRepository.OphalenViaId(id);
            if (Store == null)
            {
                Shell.Current.DisplayAlert("Fout", $"Store met id {id} werdt niet gevonden","OK");
            }else
            {
                Shell.Current.DisplayAlert("Store gevonden", Store.Name, "Sluiten");
            }
            IsBusy = false;





        }








    }
}