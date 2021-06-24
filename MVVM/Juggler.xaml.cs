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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for Juggler.xaml
    /// </summary>
    public partial class Juggler : UserControl
    {
        public Juggler()
        {
            InitializeComponent();

            StartJuggle();
        }


        public void StartJuggle()
        {
            Storyboard movingPerson = (this.Resources["MovingPerson"] as Storyboard);

            movingPerson.RepeatBehavior = RepeatBehavior.Forever;

            movingPerson.Begin();
        }

    }
}