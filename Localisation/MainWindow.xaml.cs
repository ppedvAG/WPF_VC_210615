using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Localisation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Testen der aktuellen Sprache
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                //Ändern der Sprache
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            else
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            //Neu-Öffnen des aktuellen Fensters (mit neuer Sprache)
            new MainWindow().Show();

            //Schließen des alten Fensters
            this.Close();
        }

        public TestEnum SelectedEnumValue { get; set; }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedEnumValue.ToString());
        }
    }

    public enum TestEnum { TestEnum_1, TestEnum_2 }

    public sealed class EnumerateExtension : MarkupExtension
    {

        //Type = Enum-Typ
        public Type Type { get; set; }
        //Der Übergabe-Parameter wird in XAML direkt hinter den Aufruf der Markupextension gesetzt (vgl. XAML)
        public EnumerateExtension(Type type)
        {
            this.Type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //Umwandlung der Enums in lokalisierte Strings und Rückgabe dieser an den Aufrufer (hier wird eine ItemsSource-Property erwartet)
            string[] names = Enum.GetNames(Type);
            string[] values = new string[names.Length];

            for (int i = 0; i < names.Length; i++)
                values[i] = Loc.Strings.ResourceManager.GetString(names[i]);

            return values;
        }
    }

    //Converter zum Umwandeln des Enum-Werts in ComboBoxEintrag-String
    public sealed class EnumToStringConverter : IValueConverter
    {
        //Enum -> lokalisierter ComboBoxEintrag
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            //Zugriff auf ResX
            return Loc.Strings.ResourceManager.GetString(value.ToString());
        }

        //lokalisierter ComboBoxEintrag -> Enum
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = (string)value;

            foreach (object enumValue in Enum.GetValues(targetType))
            {
                if (str == Loc.Strings.ResourceManager.GetString(enumValue.ToString()))
                    return enumValue;
            }

            throw new ArgumentException(null, "value");
        }
    }
}
