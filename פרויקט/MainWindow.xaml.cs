using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace פרויקט
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
     
       
        


        public MainWindow()
        {
            InitializeComponent();

        }









        private void txtYourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the text from the TextBox
            Name player = new Name(txtYourName.Text);
            User.Text = "Name :" +player.getName();
           
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string player = txtYourName.Text;
            Name playerCheck = new Name();
            if (playerCheck.IsOk(player))
            {
                string updatedName = playerCheck.UpdateName(player);

                try
                {
                    SecondWindow name2 = new SecondWindow(updatedName);
                    name2.Show();
                    Application.Current.MainWindow.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }  
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
