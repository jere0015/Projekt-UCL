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
using System.Windows.Shapes;

namespace Projekt_UCL
{
    /// <summary>
    /// Interaction logic for OpretPerson.xaml
    /// </summary>
    public partial class OpretPerson : Window
    {
        public OpretPerson()
        {
            InitializeComponent();
        }
        string Gender;
        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpretTB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Mand";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Gender = "Kvinde";
        }
    }
}
