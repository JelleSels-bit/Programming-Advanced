using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMol.ViewModels
{
    [QueryProperty(nameof(Deelnemers),"Deelnemers")]
    public partial class ControleViewModel:BaseViewModel
    {
    [ObservableProperty] private ObservableCollection<Deelnemer> deelnemers;
    [ObservableProperty] private string veranderKleur;
    [ObservableProperty] private string input;

    private readonly IDeelnemerRepository _deelnemerRepository;


    public ControleViewModel(IDeelnemerRepository deelnemerRepository)
    {
        _deelnemerRepository = deelnemerRepository;
        Deelnemers = new ObservableCollection<Deelnemer>(_deelnemerRepository.GetDeelnemers());
        VeranderKleur = "White";
        Input = string.Empty;
    }


    [RelayCommand]
    public void ControleerPersoon()
    {
        Deelnemer deelnemer = Deelnemers.FirstOrDefault(d => d.Voornaam == Input);

        if (deelnemer == null) return;

        int laagsteScore = Deelnemers.Min(d => d.Score);

        if (deelnemer.Rol != Rol.Mol && deelnemer.Score == laagsteScore)
        {
            VeranderKleur = "Red";
        }
        else
        {
            VeranderKleur = "Green";
        }



    }

    public int MinScoreBepalen()
    {
        int minScore = 1000;
        foreach (Deelnemer deelnemer in Deelnemers)
        {
            if (deelnemer.Score <= minScore)
            {
                deelnemer.Score = minScore;;
            }
        }
        return minScore;
    }


    }
}
