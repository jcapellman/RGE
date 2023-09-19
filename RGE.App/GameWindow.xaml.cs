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

        public GameWindow()
        {

            InitializeComponent();
          //  DataContext = new MainWindowVM(game);

        }
    }
}