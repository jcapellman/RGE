using System.Collections.Generic;
using System.Windows;

using RGE.Engine.ViewModels;
using RGE.Lib.Abstractions;

namespace RGE.Engine
{
    /// <summary>
    /// Interaction logic for GameSelection.xaml
    /// </summary>
    public partial class GameSelectionWindow : Window
    {
        private GameSelectionWindowVM Context => (GameSelectionWindowVM)DataContext;

        public GameSelectionWindow(List<BaseGame> games)
        {
            InitializeComponent();

            DataContext = new GameSelectionWindowVM(games);
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            var gameWindow = new GameWindow(Context.SelectedGame);

            gameWindow.Show();

            Close();
        }
    }
}