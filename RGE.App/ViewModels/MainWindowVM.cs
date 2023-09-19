using System;
using System.IO;
using System.Linq;
using System.Reflection;

using RGE.App.ViewModels.Base;
using RGE.Lib.Abstractions;

namespace RGE.App.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        public BaseGame Game
        {
            get => _game;

            set { _game = value; OnPropertyChanged(); }
        }

        private BaseGame _game;

        private BaseGame? LoadGame()
        {
            var potentialGames = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");

            foreach (var file in potentialGames)
            {
                try
                {
                    var assembly = Assembly.LoadFile(file);

                    var game = assembly.GetTypes().FirstOrDefault(a => a.BaseType == typeof(BaseGame));

                    if (game != null)
                    {
                        return (BaseGame)Activator.CreateInstance(game)!;
                    }
                } catch (Exception) { }
            }

            return null;
        }

        public MainWindowVM()
        {
            var game = LoadGame();

            if (game is not null)
            {
                Game = game;
            }
        }
    }
}