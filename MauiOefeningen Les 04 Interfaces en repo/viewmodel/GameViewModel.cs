using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.viewmodel
{
    public partial class GameViewModel : BaseViewModel
    {
       private readonly IGameRepository _gameRepository;

        [ObservableProperty]
        ObservableCollection<Game> games;

        [ObservableProperty]
        Game game;

        public GameViewModel(IGameRepository gameRepository)
        {
            Title = "GamePage";
            _gameRepository = gameRepository;
            games = new ObservableCollection<Game>(_gameRepository.GetGames());
            game = new Game();
        }

        [RelayCommand]
        public void gameToevoegen()
        {
            if (!Games.Contains(Game))
            {
                Games.Add(Game);
            }
        }

        [RelayCommand]
        public void nieuweGame()
        {
            Game = new Game();

        }

    }
}
