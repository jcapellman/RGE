using System.Collections.Generic;
using System.Linq;

using RGE.Engine.ViewModels.Base;
using RGE.Lib.Abstractions;

namespace RGE.Engine.ViewModels
{
    public class GameSelectionWindowVM : BaseViewModel
    {
        public List<BaseGame> Games
        {
            get => _games;

            set
            {
                _games = value;

                OnPropertyChanged();
            }
        }

        private List<BaseGame> _games;

        public BaseGame SelectedGame
        {
            get => _selectedGame;

            set
            {
                _selectedGame = value;

                OnPropertyChanged();
            }
        }

        private BaseGame _selectedGame;

        public GameSelectionWindowVM(List<BaseGame> games)
        {
            Games = games;

            SelectedGame = Games.First();
        }
    }
}