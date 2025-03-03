
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
        public async void VragenBeantwoorden()
        {
            if (Deelnemers == null && Deelnemer == null)
            {
                await Shell.Current.DisplayAlert("Fout", "Je moet een deelnemer selecteren of de lijst is leeg :)", "ok");
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(VraagPage), true, new Dictionary<string, object>
                {
                    {"Deelnemers",Deelnemers},
                    {"Deelnemer", Deelnemer}
                });
            }
            
            

            
                    
            
            

        }
        
    }
}
