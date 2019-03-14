using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static Projekt_UCL.DatabaseController;


namespace Projekt_UCL
{
    /// <summary>
    /// Interaction logic for OpretPerson.xaml
    /// </summary>
    public partial class OpretPerson : Window
    {
        DatabaseController databaseController = new DatabaseController();
        public OpretPerson()
        {
            InitializeComponent();
            databaseController.GetPerson(this);
        }
        
        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpretTB_Click(object sender, RoutedEventArgs e)
        {
            databaseController.InsertPerson(fornavnTB.Text, kønTB.Text);
            listViewTB.Items.Add(new Person
            {
                Fornavn = fornavnTB.Text,
                Køn = kønTB.Text
            });

            fornavnTB.Text = "";
            kønTB.Text = "";
        }

        private void SletTB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = (Person)listViewTB.SelectedItems[0];
                databaseController.DeletePerson(person.Fornavn);
                listViewTB.Items.RemoveAt(listViewTB.SelectedIndex);
            }
            catch (System.ArgumentOutOfRangeException) { }
        }

        GridViewColumnHeader lastHeaderClicked = null; 
        ListSortDirection lastDirection = ListSortDirection.Ascending;

        private void NameHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            ListSortDirection direction;
            if (column != lastHeaderClicked)
            {
                direction = ListSortDirection.Ascending;
            }
            else
            {
                if (lastDirection == ListSortDirection.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
            }

            string header = column.Tag.ToString();
            listViewTB.Items.SortDescriptions.Clear();
            listViewTB.Items.SortDescriptions.Add(new SortDescription(header, direction));

            lastDirection = direction;
            lastHeaderClicked = column;
        }
    }
} 
