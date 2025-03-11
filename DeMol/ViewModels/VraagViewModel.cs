using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeMol.ViewModels
{
    [QueryProperty(nameof(Deelnemers),"Deelnemers")]
    [QueryProperty(nameof(Deelnemer),"Deelnemer")]
    public partial class VraagViewModel : BaseViewModel
    {
        [ObservableProperty] private ObservableCollection<Deelnemer> deelnemers;
        [ObservableProperty] private Deelnemer deelnemer;

        [ObservableProperty] private ObservableCollection<Vraag> vragen;

        [ObservableProperty] private int? antwoord;
        [ObservableProperty] private Vraag vraag;
        [ObservableProperty] private bool pasVraagCheck;

        [ObservableProperty] private int vragenOpteller;
        [ObservableProperty] private bool pasVraagGebruikt;
        [ObservableProperty] private bool vragenBeantwoord;
        [ObservableProperty] private bool vragenWeergeven;
        [ObservableProperty] private bool allesIngevuld;



        private readonly IVraagRepository _vraagRepository;
        public bool HeeftBeantwoord => Antwoord.HasValue;
        public VraagViewModel(IVraagRepository VraagRepository)
        {
            _vraagRepository = VraagRepository;
            Vragen = new ObservableCollection<Vraag>(_vraagRepository.GetVragen());
            Deelnemer = new();
            Title = $"Welkom {Deelnemer.VolledigeNaam}";
            Antwoord = 0;
            VragenOpteller = 0;
            Vraag = Vragen[VragenOpteller];
            PasVraagCheck = true;
            PasVraagGebruikt = false;
            VragenBeantwoord = false;
            VragenWeergeven = true;
            AllesIngevuld = false;





        }

        partial void OnDeelnemerChanging(Deelnemer value)
        {
            Console.WriteLine($"Nieuwe deelnemer ontvangen: {value?.Voornaam}, PasVragen: {value?.PasVragen}");

            if (value != null && value.PasVragen > 0)
            {
                PasVraagCheck = true;

            }
            else
            {
                PasVraagCheck = false;
            }

            Console.WriteLine($"PasVraagCheck na update: {PasVraagCheck}");
            OnPropertyChanged(nameof(PasVraagCheck));
        }

        partial void OnAntwoordChanged(int? value)
        {
            OnPropertyChanged(nameof(HeeftBeantwoord));
        }

        [RelayCommand]
        public async Task NaarControlPage()
        {
            await Shell.Current.GoToAsync( nameof(ControlePage), true, new Dictionary<string, object>
            {
                {"Deelnemers",Deelnemers}

            });

        }


        [RelayCommand]
        public async Task TerugNaarHome()
        {
            VragenOpteller = 0;
            VragenBeantwoord = false;
            VragenWeergeven = true;
            Deelnemer = new Deelnemer();
            Antwoord = 0;

            if (Vragen.Any())
            {
                Vraag = Vragen[0];
            }



            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        [RelayCommand]
        public async Task VolgendeVraag()
        {
            if (Antwoord == 0)
            {
                await Shell.Current.DisplayAlert("Vraag", "Je moet een antwoord geven", "OK");
                return;

            }
        
            if (PasVraagGebruikt)
            {
                Deelnemer.Score++;
                Deelnemer.PasVragen--;
                PasVraagGebruikt = false;
            }
            if (Antwoord == Vraag.DeelnemerId)
            {
                Deelnemer.Score++;
            }

            PasVraagCheck = Deelnemer.PasVragen > 0;
            OnPropertyChanged(nameof(PasVraagCheck));

        
            if (VragenOpteller < Vragen.Count - 1)
            {
                Vraag = Vragen[++VragenOpteller]; 
            }
            else
            {
                Deelnemer.NietIngevuld = false;
                VragenWeergeven = false;
                VragenBeantwoord = true;
            }

            if (CheckAllesIngevuld())
            {
                VragenBeantwoord = false;
                AllesIngevuld = true;
            }


        }

        public bool CheckAllesIngevuld()
        {
            foreach (Deelnemer deelnemer in Deelnemers)
            {
                if (deelnemer.NietIngevuld)
                {
                    return false;
                }
            }

            return true;
        }
        
        
        
    }
}
