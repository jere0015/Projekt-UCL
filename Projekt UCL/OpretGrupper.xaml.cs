﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            if (Person.GetPeople != null)
            {
                Person.GetPeople.Clear();
            }
            OpretPerson.Count = 0;
            DatabaseController.Instance.GetPeople(this);
            count2.Content = "Antal: " + OpretPerson.Count;
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

                OpretPerson.Count--;
                count2.Content = "Antal: " + OpretPerson.Count;
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

        private void LavGrupper_Click(object sender, RoutedEventArgs e)
        {
            List<Gruppe> grupper = new List<Gruppe>();

            string location = AppDomain.CurrentDomain.BaseDirectory.ToString();
            location += @"\";
            location += navnGruppe.Text;
            location += ".txt";

            Random random = new Random();
            int count = Person.GetPeople.Count;

            for (int i = 0; i < Person.GetPeople.Count / int.Parse(maxAntal.Text); i++)
            {
                Gruppe gruppe = new Gruppe();
                grupper.Add(gruppe);
            }

            if (Person.GetPeople.Count % int.Parse(maxAntal.Text) != 0)
            {
                Gruppe gruppe = new Gruppe();
                grupper.Add(gruppe);
            }

            MessageBox.Show("Udført");
            maxAntal.Text = "";
            navnGruppe.Text = "";

            while (count > 1)
            {
                count--;
                int k = random.Next(count + 1);
                Person person = Person.GetPeople[k];
                Person.GetPeople[k] = Person.GetPeople[count];
                Person.GetPeople[count] = person;
            }

            List<Person> temp = new List<Person>();

            for (int i = 0; i < Person.GetPeople.Count; i++)
            {
                if (Person.GetPeople[i].Køn == "Dreng")
                {
                    temp.Add(Person.GetPeople[i]);
                }
            }

            for (int i = 0; i < Person.GetPeople.Count; i++)
            {
                if (Person.GetPeople[i].Køn == "Pige")
                {
                    temp.Add(Person.GetPeople[i]);
                }
            }
            Person.GetPeople = temp;

            for (int i = 0; i < grupper.Count; i++)
            {
                for (int idx = i; idx < Person.GetPeople.Count; idx += grupper.Count)
                {
                    grupper[i].People.Add(Person.GetPeople[idx]);
                }
            }

            if (File.Exists(location))
            {
                File.Delete(location);
            }

            int gruppecount = grupper.Count;

            using (StreamWriter sw = File.CreateText(location))
            {
                foreach (Gruppe gruppe in grupper)
                {
                    gruppecount--;
                    foreach (Person person in gruppe.People)
                    {
                        sw.WriteLine(person.Fornavn);
                    }
                    if (gruppecount != 0)
                    {
                        sw.WriteLine(" ");
                    }
                }
            }
        }

        private void MaxAntal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (maxAntal.Text == "" || navnGruppe.Text == "")
            {
                lavGrupper.IsEnabled = false;
            }
            else
            {
                lavGrupper.IsEnabled = true;
            }
        }

        private void NavnGruppe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (maxAntal.Text == "" || navnGruppe.Text == "")
            {
                lavGrupper.IsEnabled = false;
            }
            else
            {
                lavGrupper.IsEnabled = true;
            }
        }
    }
}
