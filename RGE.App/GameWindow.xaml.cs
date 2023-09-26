using System.Windows;

using RGE.Engine.ViewModels;
using RGE.Lib.Abstractions;

namespace RGE.Engine
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameWindowVM VM => (GameWindowVM)DataContext;

        public GameWindow(BaseGame game)
        {
            InitializeComponent();

            DataContext = new GameWindowVM(game);

            Loaded += GameWindow_Loaded;
        }

        private async void GameWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await VM.Game?.InitializeAsync()!;
        }
    }
}