using System;
using System.Linq;
using System.Windows;
using RGE.Lib.Abstractions;
using RGE.Lib.Managers;

namespace RGE.Engine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static async void StartGame(BaseGame game)
        {
            var initialize = await game.InitializeAsync();

            if (!initialize)
            {
                // TODO: Log/Error Handling

                return;
            }

            game.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var games = GameManager.LoadGames(AppContext.BaseDirectory);

            if (!games.Any())
            {
                MessageBox.Show($"No games were found in the current launching folder ({AppContext.BaseDirectory})");

                return;
            }

            if (games.Count() == 1)
            {
                StartGame(games.First());

                return;
            }

            var gameSelectionWindow = new GameSelectionWindow(games);
            gameSelectionWindow.Show();
        }
    }
}