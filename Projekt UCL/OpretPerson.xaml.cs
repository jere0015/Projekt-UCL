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
            Count = 0;
            DatabaseController.Instance.GetPerson(this);
            count1.Content = "Antal: " + Count;
        }
        
        public static int Count { get; set; }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpretTB_Click(object sender, RoutedEventArgs e)
        {
            string køn;
            if (radioDreng.IsChecked == true)
            {
                køn = "Dreng";
            }
            else
            {
                køn = "Pige";
            }

            string navn = char.ToUpper(fornavnTB.Text[0]) + fornavnTB.Text.Substring(1);

            DatabaseController.Instance.InsertPerson(navn, køn);
            listViewTB.Items.Add(new Person
            {
                Fornavn = navn,
                Køn = køn
            });

            fornavnTB.Text = "";

            Count++;
            count1.Content = "Antal: " + Count;
        }

        private void SletTB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = (Person)listViewTB.SelectedItems[0];
                DatabaseController.Instance.DeletePerson(person.Fornavn);
                listViewTB.Items.RemoveAt(listViewTB.SelectedIndex);

                Count--;
                count1.Content = "Antal: " + Count;
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
