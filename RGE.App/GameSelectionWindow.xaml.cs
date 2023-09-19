using System.Collections.Generic;
using System.Windows;

using RGE.Lib.Abstractions;

namespace RGE.Engine
{
    /// <summary>
    /// Interaction logic for GameSelection.xaml
    /// </summary>
    public partial class GameSelectionWindow : Window
    {
        public GameSelectionWindow()
        {
            InitializeComponent();
        }

        public GameSelectionWindow(List<BaseGame> games)
        {
            InitializeComponent();

            // TODO
        }
    }
}