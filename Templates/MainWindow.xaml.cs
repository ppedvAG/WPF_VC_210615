using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Vorbereitung
            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Otto", Nachname="Meier", Alter=55},
                new Person(){Vorname="Jürgen", Nachname="Müller", Alter=78},
                new Person(){Vorname="Maria", Nachname="Schmidt", Alter=24}
            };

            this.DataContext = this;
        }

        private void Btn_ControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button funktioniert");
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Sarah", Nachname = "Schmidt", Alter = 45 });
        }

        private void Btn_Loeschen_01_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der in dem ListView angewählten Person
            if (Lbx_Personen.SelectedItem is Person)
                Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }

        private void Btn_Loeschen_02_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der Person, welche in dem Button-Tag liegt
            if ((sender as Button).Tag is Person)
                Personenliste.Remove((sender as Button).Tag as Person);
        }
    }
}
