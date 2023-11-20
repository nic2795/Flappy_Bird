using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Flappy_Bird
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // create a new instance of the timer class called game timer
        DispatcherTimer gameTimer = new DispatcherTimer();
        // new gravity integer hold the vlaue 8
        int gravity = 8;
        // score keeper
        double score;
        // new rect class to help us detect collisions
        Rect FlappyRect;
        // new boolean for checking if the game is over or not
        bool gameover = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void startGame()
        {

        }

        private void gameEngine(object sender, KeyEventArgs e)
        {

        }

        private void KeyDown_Event(object sender, KeyEventArgs e)
        {

        }

        private void KeyUp_Event(object sender, KeyEventArgs e)
        {

        }
    }
}
