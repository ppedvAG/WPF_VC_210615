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

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Hannes", Nachname="Müller", Alter=56},
                new Person(){Vorname="Anna", Nachname="Schmidt", Alter=24}
            };

            this.DataContext = this;
        }

        private void Btn_Beispiel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button funktioniert");
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Tag is Person)
                Personenliste.Remove((sender as Button).Tag as Person);
        }
    }
}
