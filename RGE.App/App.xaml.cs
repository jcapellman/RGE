using System;
using System.Linq;
using System.Windows;

using RGE.Lib.Managers;

namespace RGE.Engine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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
                var gameWindow = new GameWindow(games.First());

                gameWindow.Show();

                return;
            }

            var gameSelectionWindow = new GameSelectionWindow(games);
            gameSelectionWindow.Show();
        }
    }
}