using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace פרויקט
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {




        private Game game;
        private int num1;
        private int num2;
        private string op;
        private Name nameClass = new Name();

        public SecondWindow(string name2)
        {
            InitializeComponent();
            game = new Game();
            SetupNextQuestion();

            string hisName = nameClass.UpdateName(name2);
            Title.Text = hisName;

           

        }
        private void SetupNextQuestion()
        {
            // Call methods to set up the next question in the game
            num1 = game.RandomNums1();
            num2 = game.RandomNums2();
            op = game.Get_Operator();

            // Update the UI elements with the numbers and operator
            number1.Text = num1.ToString();
            number2.Text = num2.ToString();
            operator1.Text = op;
        }










        private void check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = int.Parse(Resault.Text);
                game.IsCheckAnswer(x);
                Rank.Text = game.GetPoints().ToString();

                // Check if the game has finished
                if (game.IsGameFinished())
                {
                    MessageBox.Show("You've completed all 5 questions!");
                    MessageBox.Show("Thank You For Playing!");
                    this.Close();  // Close the current window
                }
                else
                {
                    SetupNextQuestion(); // Move to the next question
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid Number");
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
