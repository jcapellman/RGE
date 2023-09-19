using System;
using System.Linq;

using RGE.App.ViewModels.Base;
using RGE.Lib.Abstractions;
using RGE.Lib.Managers;

namespace RGE.App.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        public BaseGame? Game
        {
            get => _game;

            set { _game = value; OnPropertyChanged(); }
        }

        private BaseGame? _game;

        public MainWindowVM()
        {
            var games = GameManager.LoadGames(AppContext.BaseDirectory);

            if (games.Count != 0)
            {
                Game = games.First();
            }
        }
    }
}