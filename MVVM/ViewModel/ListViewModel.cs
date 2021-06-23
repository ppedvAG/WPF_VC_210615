using MVVM.Model;
using MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    public class ListViewModel
    {
        //Command-Properties
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }
        public CustomCommand SchliessenCmd { get; set; }

        //Listen-Property, welche auf die Liste des Models verlinkt
        public ObservableCollection<Person> Personenliste { get { return Model.Person.Personenliste; } }

        public ListViewModel()
        {
            //Command-Definitionen
            //Hinzufügen einer neuen Person
            NeuCmd = new CustomCommand
                (
                   //Exe:
                   p =>
                   {
                       //Instanzieren eines neuen DetailViews
                       DetailView dialog = new DetailView();

                       //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult(wird true, wenn der Benutzer OK klickt)
                       if (dialog.ShowDialog() == true)
                       {
                           //Hinzufügen der neuen Person zu Liste
                           Personenliste.Add((dialog.DataContext as DetailViewModel).NeuePerson);
                       }
                   }
                );

            //Ändern einer bestehenden Person
            AendernCmd = new CustomCommand
                (
                   //Exe:
                   p =>
                   {
                       //Vgl. NeuCmd (s.o.)
                       DetailView dialog = new DetailView();
                       //Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                       (dialog.DataContext as DetailViewModel).NeuePerson = new Person(p as Person);
                       //Ändern des Titels des neuen DetailViews
                       dialog.Title = (dialog.DataContext as DetailViewModel).NeuePerson.Vorname + " " + (dialog.DataContext as DetailViewModel).NeuePerson.Nachname;

                       if (dialog.ShowDialog() == true)
                           //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                           Personenliste[Personenliste.IndexOf(p as Person)] = (dialog.DataContext as DetailViewModel).NeuePerson;

                   },
                   //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                   //Fungiert als Null-Prüfung
                   p => p is Person
                  );

            //Löschen einer Person
            LoeschenCmd = new CustomCommand
                (
                    //Exe: Löschen der ausgewählten Person (nach Rückfrage per MessageBox)
                    p =>
                    {
                        if (MessageBox.Show("Soll diese Person wirklich gelöscht werden?", $"{(p as Person).Vorname} {(p as Person).Nachname} löschen?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            Personenliste.Remove(p as Person);

                    },
                    //CanExe: s.o.
                    p => p is Person
                );

            //Schließen des Programms
            SchliessenCmd = new CustomCommand
                (
                    //Exe: Schließen der Applikation
                    p => Application.Current.Shutdown()
                );
        }

    }
}

