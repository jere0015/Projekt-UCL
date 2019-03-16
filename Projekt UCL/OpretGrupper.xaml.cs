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
            DatabaseController.Instance.GetPeople(this);
        }

        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SletTB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = (Person)listViewTB.SelectedItems[0];

                for (int i = 0; i < Person.GetPeople.Count; i++)
                {
                    if (person.Fornavn == Person.GetPeople[i].Fornavn)
                    {
                        Person.GetPeople.Remove(Person.GetPeople[i]);
                    }
                }

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
