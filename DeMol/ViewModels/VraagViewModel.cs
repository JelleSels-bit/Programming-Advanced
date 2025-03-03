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

        [ObservableProperty] private int antwoord;
        [ObservableProperty] private Vraag vraag;

        [ObservableProperty] private int vragenOpteller;

        private readonly IVraagRepository _vraagRepository;
        public VraagViewModel(IVraagRepository VraagRepository)
        {
            _vraagRepository = VraagRepository;
            Vragen = new ObservableCollection<Vraag>(_vraagRepository.GetVragen());
            Title = "Vragen";
            antwoord = 0;
            VragenOpteller = 0;
            Vraag = Vragen[VragenOpteller];
            Deelnemer = new();

        }

        [RelayCommand]
        public void VolgendeVraag()
        {
            if (Antwoord == Vraag.DeelnemerId)
            {
                Deelnemer.Score++;
                
            }
            
            Vraag = Vragen[VragenOpteller++];

        }
        
        
        
    }
}
