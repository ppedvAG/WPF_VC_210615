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
using System.Windows.Shapes;

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for Db_Uebersicht.xaml
    /// </summary>
    public partial class Db_Uebersicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Rainer", Nachname="Zufall", Geburtsdatum=new DateTime(1987, 5, 13), Verheiratet=true, Lieblingsfarbe=Colors.DarkSeaGreen, Geschlecht=Gender.Männlich, Kinder=2},
            new Person(){Vorname="Anna", Nachname="Nass", Geburtsdatum=new DateTime(1974, 11, 29), Verheiratet=false, Lieblingsfarbe=Colors.LightBlue, Geschlecht=Gender.Weiblich, Kinder=0}
        };

        public Db_Uebersicht()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Mei_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            Person person = Dgd_Personen.SelectedItem as Person;

            if (MessageBox.Show($"Soll {person.Vorname} {person.Nachname} wirklich gelöscht werden?", $"{person.Vorname} {person.Nachname} löschen?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Personenliste.Remove(person);
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            PersonenDialog dialog = new PersonenDialog();

            if (dialog.ShowDialog() == true)
            {
                Personenliste.Add(dialog.DataContext as Person);
            }
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            PersonenDialog dialog = new PersonenDialog();

            dialog.DataContext = new Person(Dgd_Personen.SelectedItem as Person);

            dialog.Title = (dialog.DataContext as Person).Vorname + " " + (dialog.DataContext as Person).Nachname;

            if (dialog.ShowDialog() == true)
                Personenliste[Dgd_Personen.SelectedIndex] = (dialog.DataContext as Person);
        }
    }
}
