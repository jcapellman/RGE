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
        public GameWindow(BaseGame game)
        {
            InitializeComponent();

            DataContext = new GameWindowVM(game);
        }
    }
}