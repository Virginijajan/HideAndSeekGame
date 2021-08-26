using HideAndSeek;
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

namespace HideAndSeekUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController gameController;
        public string Message;
        public MainWindow()
        {
           InitializeComponent();

           gameController = Resources["gameController"] as GameController;


            directions.Items.Add(Direction.North);
            directions.Items.Add(Direction.South);
            directions.Items.Add(Direction.East);
            directions.Items.Add(Direction.West);
            directions.Items.Add(Direction.Northeast);
            directions.Items.Add(Direction.Southwest);
            directions.Items.Add(Direction.Southeast);
            directions.Items.Add(Direction.Northwest);
            directions.Items.Add(Direction.Up);
            directions.Items.Add(Direction.Down);
            directions.Items.Add(Direction.In);
            directions.Items.Add(Direction.Out);

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameController.GameOver)
            {
              return;
            }
            else message.Text = gameController.ParseInput(directions.Text);


        }

        private void saveGame_Click(object sender, RoutedEventArgs e)
        {
            message.Text=gameController.ParseInput($"Save {fileName.Text}");
        }

        private void loadGame_Click(object sender, RoutedEventArgs e)
        {
            message.Text=gameController.ParseInput($"Load {fileName.Text}");
        }

        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            gameController.NewGame();
            message.Text = "";
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            if (gameController.GameOver)
            {    
                return;
            }
            else message.Text= gameController.ParseInput("check");
        }
    }
}
