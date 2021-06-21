using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validation
{
    //Klasse, welche es ermöglicht Sammlungen von Validierungsregeln in den Ressourcen zu definieren (vgl. Xaml)
    public class ValidationRuleCollection : Collection<ValidationRule> { }
    
    //Für ValidatesOnDataErrors muss z.B. das Interface IDataErrorInfo implementiert werden. Dieses erfordert die Einbindung von zwei zusätzlichen
    public class Person : IDataErrorInfo
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                //Bei ValidatesOnException wird im Fehlerfall eine Exception geworfen, welche von der GUI aufgefangen
                //wird und als Validierungsfehler interpretiert wird. Die Exception-Message ist der
                //ErrorContent
                if (value.All(x => Char.IsLetter(x)))
                    name = value;
                else
                    throw new Exception("Bitte gib nur Buchstaben ein.");
            }
        }

        public int Alter { get; set; }


        //Von IDataErrorInfo geforderte Properties

        //Error wird von WPF nicht benutzt
        public string Error => null;

        //Diese Property wird von der GUI als Validierung verwendet. Wenn ein nicht-leerer String zurückgegeben wird, 
        //dann wird dies als Fehler interpretiert und dieser String als Fehlermeldung
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case (nameof(Alter)):
                        if (Alter < 0 || Alter > 150) return "Bitte gib dein wahres Alter an.";
                        break;
                    default:
                        break;
                }

                return null;
            }
        }
    }
}
