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
        public App()
        {
            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var games = GameManager.LoadGames(AppContext.BaseDirectory);

            if (!games.Any())
            {
                MessageBox.Show($"No games were found in the current launching folder ({AppContext.BaseDirectory})");

                return;
            }

            if (games.Count() == 1)
            {
                Application.Current.MainWindow = new GameWindow();

                Application.Current.MainWindow.Show();

                return;
            }

            Application.Current.MainWindow = new GameSelectionWindow(games);
            Application.Current.MainWindow.Show();
        }
    }
}