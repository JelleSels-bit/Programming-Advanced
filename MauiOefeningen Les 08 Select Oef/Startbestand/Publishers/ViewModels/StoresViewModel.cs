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
        private string state;





        public StoresViewModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            Stores = [];
            State = "";
        }

        [RelayCommand]
        public void OphalenStoresViaStaat()
        {
            Stores = new ObservableCollection<Store>(_storeRepository.OphalenStoresViaStaat(State));
        }

        [RelayCommand]
        public void OphalenStoresViaNaam()
        {

        }

        [RelayCommand]
        public void OphalenStoresViaNaamEnStaat()
        {

        }

        [RelayCommand]
        public void OphalenStoresViaId()
        {

        }

    }
}