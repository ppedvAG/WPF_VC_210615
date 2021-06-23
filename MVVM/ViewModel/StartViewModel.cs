using MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    public class StartViewModel : INotifyPropertyChanged
    {
        //Im ViewModel-Teil eines MVVM-Programms werden Klassen definiert, welche als Verbindungsstück zwischen den Views und den Modelklassen fungieren.
        //Diese Klassen sind die einzigen Programmteile, welche Referenzen auf Model-Klassen beinhalten. Sie selbst sind jeweils einem View zugrordnet,
        //mit welchem sie (nur) über den DataContext des jeweiligen Views verbunden sind.

        //Command-Properties
        public CustomCommand LadeDbCmd { get; set; }
        public CustomCommand OeffneDbCmd { get; set; }

        //Property zur Repräsentation der Anzahl der geladenen Personen (Getter verlinkt an die Model-Klasse)
        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; } }

        //Konstruktor
        public StartViewModel()
        {
            //Befüllung der Commands
            LadeDbCmd = new CustomCommand
                (
                    //Exe: führe Methode aus Model aus und informiere die GUI über Veränderung in der 'AnzahlPersonen'-Property
                    p =>
                    {
                        //Aufruf der 'Datenbank'-Lade-Funktion
                        Model.Person.LadePersonenAusDb();
                        //Benachrichtigung der GUI über Veränderung in der 'AnzahlPersonen'-Property
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPersonen)));
                    },
                    //CanExe: Cmd kann ausgeführt werden, wenn die Anzahl der geladenen Personen = 0 ist
                    p => AnzahlPersonen == 0
                    );
            OeffneDbCmd = new CustomCommand
                (
                    //Exe:
                    p =>
                    {
                        //Instanzierung eines neunen ListViews
                        ListView db_Ansicht = new ListView();
                        //Anzeigen des neuen ListViews
                        db_Ansicht.Show();
                        //Schließen dieses Fensters (welches über den CommandParameter übergeben wurde)
                        (p as Window).Close();
                    },
                    //CanExe: Cmd kann ausgeführt werden, wenn die Anzahl der geladenen Personen > 0 ist
                    p => AnzahlPersonen > 0
                    );
        }

        //Event, welches die GUI über Veränderungen informiert
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
