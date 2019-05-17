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

namespace Homework_5
{

    public enum MOVE
    {
        NONE = 0,
        CROSS = 1,
        CIRCLE = 2,
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int[,] choices;
        bool turn;
        int winner;
        int turns = 0;

        public MainWindow()
        {
            InitializeComponent();
            resetBoard();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            resetBoard();
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (winner > 0)
                return;

            if (sender is Button button)
            {
                if (isEmptySpot(button))
                {
                    turns++;

                    int[] coords = button.Tag.ToString().Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    MOVE move = turn ? MOVE.CIRCLE : MOVE.CROSS;
                    int moveValue = Convert.ToInt32(move);
                    choices[coords[0], coords[1]] = moveValue;
                    button.Content = turn ? "O" : "X";

                    if (isWinner(moveValue))
                    {
                        winner = moveValue;
                        uxTurn.Text = button.Content + " is a winnder";
                        uxGrid.IsEnabled = false;
                    }
                    else
                    {
                        if (turns >= 9)
                        {
                            uxTurn.Text = "Game is a draw";
                            uxGrid.IsEnabled = false;
                        }
                        else
                        { uxTurn.Text = (turn ? "X" : "O") + "'s turn"; }
                    }

                    turn = !turn;
                }
            }
        }

        private bool isWinner(int moveValue)
        {
            // Check for horizontal wins
            for (int row = 0; row < 3; row++)
            {
                if (choices[row, 0].Equals(moveValue) && choices[row, 1].Equals(moveValue) && choices[row, 2].Equals(moveValue))
                    return true;
            }

            // Check for Vertical wins
            for (int col = 0; col < 3; col++)
            {
                if (choices[0, col].Equals(moveValue) && choices[1, col].Equals(moveValue) && choices[2, col].Equals(moveValue))
                    return true;
            }

            if (choices[0, 0].Equals(moveValue) && choices[1, 1].Equals(moveValue) && choices[2, 2].Equals(moveValue))
                return true;

            if (choices[0, 2].Equals(moveValue) && choices[1, 1].Equals(moveValue) && choices[2, 0].Equals(moveValue))
                return true;

            return false;
        }

        private IEnumerable<Button> GetButtons()
        {
            return uxGrid.Children.OfType<Button>().Select(x => x);
        }

        private bool isEmptySpot(Button button)
        {
            return button.Content is null || button.Content.Equals("");
        }

        public void resetBoard()
        {
            choices = new int[3, 3];
            turn = false;
            turns = 0;
            foreach (Button button in GetButtons())
            {
                button.Content = null;
            }
            winner = 0;
            uxTurn.Text = "X's turn";
            uxGrid.IsEnabled = true;
        }

    }

}
