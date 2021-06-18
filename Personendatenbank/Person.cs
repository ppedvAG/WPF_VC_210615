using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Personendatenbank
{
    public enum Gender { Männlich, Weiblich, Divers }

    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string vorname;
        public string Vorname { get => vorname; set { vorname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname))); } }

        private string nachname;
        public string Nachname { get => nachname; set { nachname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nachname))); } }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum { get => geburtsdatum; set { geburtsdatum = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geburtsdatum))); } }

        private bool verheiratet;
        public bool Verheiratet { get => verheiratet; set { verheiratet = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Verheiratet))); } }

        private Color lieblingsfarbe;
        public Color Lieblingsfarbe { get => lieblingsfarbe; set { lieblingsfarbe = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieblingsfarbe))); } }

        private Gender geschlecht;
        public Gender Geschlecht { get => geschlecht; set { geschlecht = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geschlecht))); } }

        public Person()
        {
            this.Vorname = String.Empty;
            this.Nachname = String.Empty;
            this.Geburtsdatum = DateTime.Now;
        }
    }
}

