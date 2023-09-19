using RGE.Engine.ViewModels.Base;
using RGE.Lib.Abstractions;

namespace RGE.Engine.ViewModels
{
    public class GameWindowVM : BaseViewModel
    {
        public BaseGame? Game
        {
            get => _game;

            set { _game = value; OnPropertyChanged(); }
        }

        private BaseGame? _game;

        public GameWindowVM(BaseGame? game)
        {
            Game = game;
        }
    }
}