using RGE.Engine.ViewModels.Base;
using RGE.Lib.Abstractions;

using System.Text;

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

        private StringBuilder _sbLog = new();

        public string Log
        {
            get => _sbLog.ToString();

            set
            {
                _sbLog.Append(value);

                OnPropertyChanged();
            }
        }


        public GameWindowVM(BaseGame? game)
        {
            Log = string.Empty;

            Game = game;

            Game?.Initialize();

            Game?.Run();
        }
    }
}