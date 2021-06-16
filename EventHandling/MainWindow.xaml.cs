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

namespace EventHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Event, welches von den StackPanels während der Tunneling-Phase geworfen wird
        private void SP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Leeren des Textblocks zu Beginn und Ausgabe des OriginalSource-Objekts
            if ((sender as FrameworkElement).Name == "Aqua")
                Tbl_Output.Text = $"Origin: {(e.OriginalSource as FrameworkElement)?.Name}\n\n";

            //Ausgabe des Namens des werfenden StackPanles (sender)
            Tbl_Output.Text += (sender as FrameworkElement).Name + " Tunnel/Preview\n";
        }

        //Event, welches von den StackPanels während der Bubbleing-Phase geworfen wird
        private void SP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Ausgabe des Namens des werfenden StackPanles (sender)
            Tbl_Output.Text += (sender as FrameworkElement).Name + " Bubble\n";

            //Handling des Events abschließen (= Weiterleitung wird unterbunden), wenn der Name des werfenden StackPanels "Gelb" ist
            if ((sender as FrameworkElement).Name == "Gelb")
            {
                e.Handled = true;
                Tbl_Output.Text += "Handled\n";
            }
        }

        //Click-Event des Buttons (Automatischer Handling-Abschluss)
        private void Btn_Klick_Click(object sender, RoutedEventArgs e)
        {
            //Ausgabe
            Tbl_Output.Text += (sender as FrameworkElement).Name + " Click\n";
        }

        private void Tbx_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Prüfung, ob Tbl_Output bereits initalisiert ist
            if (Tbl_Output != null)
                //Ausgabe
                Tbl_Output.Text += (sender as FrameworkElement).Name + " TextChanged\n";
        }

        //ButtonBase.Click-Event des Windows -> triggert durch jeden Button im Fenster (Automatischer Handling-Abschluss)
        private void Wnd_Main_Click(object sender, RoutedEventArgs e)
        {
            //Ausgabe
            Tbl_Output.Text += (sender as FrameworkElement).Name + " ButtonBase.Click\n";
        }

        //TextBoxBase.TextChanged-Event des Windows -> triggert durch jede TextBox im Fenster
        private void Wnd_Main_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Prüfung, ob Tbl_Output bereits initalisiert ist
            if (Tbl_Output != null)
                //Ausgabe
                Tbl_Output.Text += (sender as FrameworkElement).Name + " TextBoxBase.TextChanged\n";
        }
    }
}

