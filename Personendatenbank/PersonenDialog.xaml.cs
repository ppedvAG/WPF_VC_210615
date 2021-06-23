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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonenDialog : Window
    {
        public PersonenDialog()
        {
            InitializeComponent();
        }

        #region Logging (Lab 04)

        //Property zum Speichern des Logs
        public StringBuilder Log { get; set; } = new StringBuilder("WindowLog:\n\n");

        //Abfangen von Tastendruck
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Test, ob 'F1' gedrückt wurde
            if (e.Key == Key.F1)
                //Log-Anzeige
                MessageBox.Show(Log.ToString(), "Log", MessageBoxButton.OK);

            //Ansonsten: Eintrag ins Log
            else LogAction(sender, e);
        }

        //Logging einer Aktion
        private void LogAction(object sender, RoutedEventArgs e)
        {
            //Speichern des Namens des Quellelements
            string originalsource = e.OriginalSource is TextBox ? (e.OriginalSource as TextBox).Name : e.OriginalSource.ToString();

            //Testen auf Art des Events anhand der EventArgs und Eintrag ins Log
            if (e.GetType() == typeof(MouseButtonEventArgs))
                Log.Append($"{originalsource}: MouseButtonPressed: {(e as MouseButtonEventArgs).ChangedButton}");
            else if (e.GetType() == typeof(KeyEventArgs))
                Log.Append($"{originalsource}: KeyPressed: {(e as KeyEventArgs).Key}");
            else if (e.GetType() == typeof(TextChangedEventArgs))
                Log.Append($"{originalsource}: TextChanged: {(e.OriginalSource as TextBox).Text}");
            else
                Log.Append($"{originalsource}: Unknown Event");

            //Neue Zeile im Log
            Log.Append(Environment.NewLine);
        }
        #endregion

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Person neuePerson = this.DataContext as Person;

            string ausgabe = neuePerson.Vorname + " " + neuePerson.Nachname + " (" + neuePerson.Geschlecht + ")\n" + neuePerson.Geburtsdatum.ToShortDateString() + "\n" + neuePerson.Lieblingsfarbe.ToString();
            if (neuePerson.Verheiratet) ausgabe = ausgabe + "\nIst verheiratet";
            if (neuePerson.Kinder > 0) ausgabe = ausgabe + $"\nHat {neuePerson.Kinder} {(neuePerson.Kinder == 1 ? "Kind" : "Kinder")}";
            if (MessageBox.Show(ausgabe + "\nAbspeichern?", neuePerson.Vorname + " " + neuePerson.Nachname, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
