using MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        //Command-Properties
        public CustomCommand OkCmd { get; set; }
        public CustomCommand AbbruchCmd { get; set; }

        //Property, welche die neue oder zu bearbeitende Person beinhaltet
        private Person neuePerson;
        public Person NeuePerson
        {
            get { return neuePerson; }
            set
            {
                neuePerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuePerson)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DetailViewModel()
        {
            NeuePerson = new Person();

            //OK-Command (Bestätigung)
            OkCmd = new CustomCommand
                (
                    //Exe:
                    p =>
                    {
                        //Nachfrage auf Korrektheit der Daten per MessageBox
                        string ausgabe = NeuePerson.Vorname + " " + NeuePerson.Nachname + " (" + NeuePerson.Geschlecht + ")\n" + NeuePerson.Geburtsdatum.ToShortDateString() + "\n" + NeuePerson.Lieblingsfarbe.ToString();
                        ausgabe += NeuePerson.Verheiratet ? "\nIst Verheiratet" : "";
                        if (MessageBox.Show(ausgabe + "\nÜbernehmen?", "Neue Person", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Setzen des DialogResults des Views (welches per Parameter übergeben wurde) auf true, damit das ListView weiß, dass es weiter
                            //machen kann (d.h. die neuen Person einfügen bzw. austauschen)
                            (p as Window).DialogResult = true;
                            //Schließen des Views
                            (p as Window).Close();
                        }
                    }
                );

            //Abbruch-Cmd
            AbbruchCmd = new CustomCommand
                (
                    //Exe: Schließen des Fensters
                    p => (p as Window).Close()
                );
        }
    }
}
