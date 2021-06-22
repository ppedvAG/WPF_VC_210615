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

namespace UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();

            //Erstellen einer neuen Bindung (Fill-Eigenschaft des Rechtecks an PickedColor-Eigenschaft)
            //Initialisierung mit Übergabe der zu Bindenden Quell-Eigenschaft
            Binding binding = new Binding("Fill");
            //Setzen des Quell-Objekts
            binding.Source = Rct_Output_2;
            //Setzen des Bindings-Modes
            binding.Mode = BindingMode.OneWay;

            //Erstellen der Bindung mit Übergabe des Ziel-Objekts, der Ziel-Eigenschaft und des Bindungs-Elements
            BindingOperations.SetBinding(this, PickedColorProperty, binding);

            //EventRaising
            Tbl_Output.PreviewMouseDown += (s, e) => RaiseTapEvent();


            //Binding bindingBeschreibung = new Binding("Text");
            //bindingBeschreibung.Source = Tbl_Beschreibung;
            //bindingBeschreibung.Mode = BindingMode.OneWayToSource;
            //bindingBeschreibung.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //BindingOperations.SetBinding(this, BeschreibungProperty, bindingBeschreibung);

        }

        //Damit der Control eine Ausgabe hat, an welche die User andere Properties binden können muss für jede dieser Ausgaben eine DependencyProperty
        //erstellt werden, welche im Konstruktor des UserControlls manuell an die entsprechnende Property eines Teilelements gebunden wird.
        //DependencyProperties sind spezielle WPF-Element-Properties, welche nicht in den Objekten selbst gespeichert werden. Stattdessen werden diese
        //in einer eigenen Liste abgelegt. Durch diese Mechanik werden Bindungen und Co in WPF erst möglich.

        //Getter/Setter der DependencyProperty
        public SolidColorBrush PickedColor
        {
            get { return (SolidColorBrush)GetValue(PickedColorProperty); }
            set { SetValue(PickedColorProperty, value); }
        }

        //Registrierung für neue Bindungen an der DependencyProperty
        public static readonly DependencyProperty PickedColorProperty =
            DependencyProperty.Register("PickedColor", typeof(SolidColorBrush), typeof(ColorPicker), new PropertyMetadata(default(SolidColorBrush)));


        public string Beschreibung
        {
            get { return (string)GetValue(BeschreibungProperty); }
            set { SetValue(BeschreibungProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Beschreibung.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BeschreibungProperty =
            DependencyProperty.Register("Beschreibung", typeof(string), typeof(ColorPicker), new PropertyMetadata("Picked Color:"));




        //AttachedProperty
        public static int GetCount(DependencyObject obj)
        {
            return (int)obj.GetValue(CountProperty);
        }

        public static void SetCount(DependencyObject obj, int value)
        {
            obj.SetValue(CountProperty, value);
        }

        public static readonly DependencyProperty CountProperty =
            DependencyProperty.RegisterAttached("Count", typeof(int), typeof(ColorPicker), new PropertyMetadata(0));

        //Zugriff auf AttachedProperty-Wert eines Content-Objekts
        void TestZugriff()
        {
            (this.Content as DependencyObject).GetValue(CountProperty);
        }



        //CustomEvent
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));

        //Handleranmeldung
        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }

        //Methode zum Feuern des Eventhandlers
        void RaiseTapEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TapEvent);
            RaiseEvent(newEventArgs);
        }

    }
}