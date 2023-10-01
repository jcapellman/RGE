using System;
using System.Linq;
using System.Windows;
using NLog;
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
                LogManager.GetCurrentClassLogger().Error($"{game.Name} could not initialize, shutting down");

                return;
            }

            game.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var games = GameManager.LoadGames(AppContext.BaseDirectory);

            switch (games.Count)
            {
                case 0:
                    MessageBox.Show($"No games were found in the current launching folder ({AppContext.BaseDirectory})");

                    return;
                case 1:
                    StartGame(games.First());

                    return;
                default:
                {
                    var gameSelectionWindow = new GameSelectionWindow(games);
                    gameSelectionWindow.Show();
                    break;
                }
            }
        }
    }
}