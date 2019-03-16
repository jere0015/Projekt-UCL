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
    /// Interaction logic for OpretGrupper.xaml
    /// </summary>
    public partial class OpretGrupper : Window
    {
        public OpretGrupper()
        {
            InitializeComponent();
            if (Person.GetPeople == null)
            {
                Person.GetPeople.Clear();
            }
            DatabaseController.Instance.GetPerson(this);
        }

        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
