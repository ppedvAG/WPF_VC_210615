using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validation
{
    public class IPv4Validation : ValidationRule
    {
        //ValidationRules müssen von der Klasse ValidationRule erben und die abstrakte Methode Validate() implementieren.
        //Diese liefert ein ValidationResult zurück, je nachdem, ob die Regel erfüllt wurde oder nicht.
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //Überprüfung, ob der eingegebene Wert (value) dem Muster einer IPv4-Adresse entspricht. Die Prüfung erfolgt hier über die RegEx-Klasse
            if (Regex.IsMatch(value.ToString(), @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
                //Wenn das Muster stimmt, wird eine Bestätigung zurückgegeben, woraufhin die GUI die Bindung erlaubt
                return ValidationResult.ValidResult;
            else
                //Andernfalls wird eine Fehlermeldung zurückgegeben
                return new ValidationResult(false, "Bitte gib eine IPv4-Adresse ein.");
        }
    }
}
