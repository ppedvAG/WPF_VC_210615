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

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Zuweisung eines weiteren EventHandlers zu dem Click-Event des Buttons
            Btn_KlickMich.Click += Btn_KlickMich_Click_2;
        }

        //Event-Handler für das Click-Event des Buttons
        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Neuzuweisung der Content-Eigenschaft des Labels mit dem ausgewählten Inhalt der ComboBox
            Lbl_Output.Content = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content;

            //Änderung der Hintergrundfarbe des Fensters
            Wnd_Main.Background = new SolidColorBrush(Colors.Blue);

            //MessageBox mit dem Inhalt der TextBox
            MessageBox.Show(Tbx_Input.Text);

            //Prüfung, ob die Checkbox abgehakt ist
            if (Cbx_Haken.IsChecked == true)
                //Anzeige einer MessageBox mit Inhalt der TextBox und Auswahl der ComboBox
                MessageBox.Show(Tbx_Input.Text + "\n" + Cbb_Auswahl.Text);
        }

        //Zweiter Eventhandeler des Buttons (siehe Konstruktor)
        private void Btn_KlickMich_Click_2(object sender, RoutedEventArgs e)
        {
            //MessageBox-Abfrage mit Überprüfung des geklickten Buttons
            switch (MessageBox.Show("JA oder NEIN?", "Meine Frage an dich", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign))
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("YES");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("No");
                    break;
            }
        }

        private void Neu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Öffen eines neuen Fensters als gleichberechtigtes Fenster
            new MainWindow() { Title = "Neues Fenster" }.Show();

            //Öffnen eines neuen Fensters als Dialogfenster mit Rückgabe des DialogResults
            bool? dialogresult = new MainWindow() { Title = "Neues Dialogfenster" }.ShowDialog();
            MessageBox.Show(dialogresult.ToString());
        }

        private void Beenden_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Schließen des Fensters
            this.Close();

            //Beenden der Applikation
            Application.Current.Shutdown();
        }
    }
}

