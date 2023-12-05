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
        DispatcherTimer gameTimer = new DispatcherTimer();
        int gravity = 8;
        double score;
        bool gameover = false;

        // new rect class to help us detect collisions
        Rect FlappyRect;

        public MainWindow()
        {
            InitializeComponent();

            // set the default settings for the timer
            gameTimer.Tick += gameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            startGame();
        }

        private void gameEngine(object sender, EventArgs e)

        {
            // this is the game engine event linked to the timer
            // first update the score text label with the score integer
            scoreText.Content = "Score: " + score;
            // link the flappy bird image to the flappy rect class
            FlappyRect = new Rect(Canvas.GetLeft(flappyBird), Canvas.GetTop(flappyBird), flappyBird.Width - 12, flappyBird.Height - 6);
            // set the gravity to the flappy bird image in the canvas
            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity);
            // check if the bird has either gone off the screen from top or bottom
            if (Canvas.GetTop(flappyBird) + flappyBird.Height > 490 || Canvas.GetTop(flappyBird) < -20)
            {
                EndGame();
            }
            // below is the main loop, this loop will go through each image in the canvas
            // if it finds any image with the tags and follow the instructions with them
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    // if we found an image with the tag obs1,2 or 3 then we will move it towards left of the scree
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    // create a new rect called pillars and link the rectangles to it
                    Rect pillars = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    // if the flappy rect and the pillars rect collide
                    if (FlappyRect.IntersectsWith(pillars))
                    {
                        EndGame();
                    }
                }
                // if the first layer of pipes leave the scene and go to -100 pixels from the left
                // we need to reset the pipe to come back again
                if ((string)x.Tag == "obs1" && Canvas.GetLeft(x) < -100)
                {
                    // reset the pipe to 800 pixels
                    Canvas.SetLeft(x, 800);
                    // add 1 to the score
                    score = score + .5;
                }
                // if the second layer of pipes leave the scene and go to -200 pixels from the left
                if ((string)x.Tag == "obs2" && Canvas.GetLeft(x) < -200)
                {
                    // we set that pipe to 800 pixels
                    Canvas.SetLeft(x, 800);
                    // add 1 to the score
                    score = score + .5;
                }
                // if the third layer of pipes leave the scene and go to -250 pixels from the left
                if ((string)x.Tag == "obs3" && Canvas.GetLeft(x) < -250)
                {
                    // we set the pipe to 800 pixels
                    Canvas.SetLeft(x, 800);
                    // add 1 to the score
                    score = score + .5;
                }
                // if find any of the images with the clouds tag on it
                if ((string)x.Tag == "clouds")
                {
                    // then we will slowly move the cloud towards left of the screen
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - .6);
                    // if the clouds have reached -220 pixels then we will reset it
                    if (Canvas.GetLeft(x) < -220)
                    {
                        // reset the cloud images to 550 pixels
                        Canvas.SetLeft(x, 550);
                    }
                }
            }
        }

        private void KeyDown_Event(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width / 2, flappyBird.Height / 2);
                gravity = -8;
            }

            if (e.Key == Key.R && gameover == true)
            {
                startGame();
            }
        }

        private void KeyUp_Event(object sender, KeyEventArgs e)
        {
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2);

            gravity = 8;
        }

        private void startGame()
        {
            MyCanvas.Focus();

            int temp = 300;

            score = 0;

            gameover = false;

            Canvas.SetTop(flappyBird, 190);

            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }

                if ((string)x.Tag == "clouds")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }

            gameTimer.Start();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            gameover = true;
            scoreText.Content += " Game Over!!! Press R to restart.";

        }

       
    }
}
