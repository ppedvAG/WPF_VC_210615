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
        public CustomCommand LoadCmd { get; set; }
        public CustomCommand OpenCmd { get; set; }

        public int PersonCount { get { return Model.Person.Personenliste.Count; } }

        public StartViewModel()
        {
            LoadCmd = new CustomCommand
                (
                    p =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonCount)));
                    },

                    p => PersonCount == 0                
                );

            OpenCmd = new CustomCommand
                (
                    p =>
                    {
                        //Open new Window

                        (p as Window).Close();
                    },

                    p => PersonCount >= 1
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
