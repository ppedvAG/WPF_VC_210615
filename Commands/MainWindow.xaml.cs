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

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //Initialisierung der Commands
            CloseCmd = new CloseCommand();
            OeffnenCmd = new CustomCommand
                (
                    //Übergabe der Execute()-Logik
                    p => (new MainWindow()).Show(),
                    //Übergabe der CanExecute()-Logik
                    p => (p as string).Length >= 1
                );

            //Setzen des DataContext
            this.DataContext = this;
        }

        //Commandproperties 
        public CloseCommand CloseCmd { get; set; }
        public CustomCommand OeffnenCmd { get; set; }
    }
}
