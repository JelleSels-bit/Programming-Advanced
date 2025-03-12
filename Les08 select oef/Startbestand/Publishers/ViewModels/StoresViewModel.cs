using Publishers.Data.Interfaces;
using Publishers.Models;

namespace Publishers.ViewModels
{
    public partial class StoresViewModel : BaseViewModel
    {
        private readonly IStoreRepository _storeRepository;

        [ObservableProperty]
        ObservableCollection<Store> stores;

        [ObservableProperty]
        ObservableCollection<Store> temp;

             
        [ObservableProperty]
        private string state = string.Empty ;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private int id = 0;





        public StoresViewModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
                
     
        }

        [RelayCommand]
        public void OphalenStoresViaStaat()
        {
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storeRepository.OphalenStoresViaStaat(State));
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenStoresViaNaam()
        {
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storeRepository.OphalenStoresViaNaam(Name));
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenStoresViaNaamEnStaat()
        {
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storeRepository.OphalenStoresViaNaamEnStaat(Name, State));
            IsBusy = false;
        }

        [RelayCommand]
        public async void OphalenStoresViaId()
        {
            IsBusy = true;
            var  Store = _storeRepository.OphalenStoreViaId(Id);
            if (Store == null)
            {
                await Shell.Current.DisplayAlert("Store niet gevonden",$"Store met id: {Id} kan niet worden gevonden","OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Store gevonden", $"{Store.Name}","OK");
            }
            IsBusy = false; 
        }

    }
}