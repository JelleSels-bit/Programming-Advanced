
namespace DeMol.ViewModels
{
    public partial class MainPageViewModel:BaseViewModel
    {

        [ObservableProperty] private Deelnemer deelnemer;
        [ObservableProperty] private ObservableCollection<Deelnemer> deelnemers;
        private readonly IDeelnemerRepository _deelnemerRepository;
        public MainPageViewModel(IDeelnemerRepository deelnemerRepository)
        {
            _deelnemerRepository = deelnemerRepository;
            Deelnemer = new();
            Deelnemers = new ObservableCollection<Deelnemer>(_deelnemerRepository.GetDeelnemers());
            
        }

        [RelayCommand]
        public async Task VragenBeantwoorden()
        {
                await Shell.Current.GoToAsync(nameof(VraagPage), true, new Dictionary<string, object>
                {
                    {"Deelnemers",Deelnemers},
                    {"Deelnemer", Deelnemer}
                });










        }
        
    }
}
