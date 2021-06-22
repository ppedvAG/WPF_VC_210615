﻿using System;
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

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for IntegerUpDown.xaml
    /// </summary>
    public partial class IntegerUpDown : UserControl
    {
        public IntegerUpDown()
        {
            InitializeComponent();

            //Binding binding = new Binding();
            //binding.Source = Tbx_Input;
            //binding.Path = new PropertyPath("Text");
            //binding.Mode = BindingMode.TwoWay;
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //BindingOperations.SetBinding(this, ValueProperty, binding);
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(IntegerUpDown), new PropertyMetadata(0));

        private void Btn_Up_Click(object sender, RoutedEventArgs e)
        {
            this.Value++;
        }

        private void Btn_Down_Click(object sender, RoutedEventArgs e)
        {
            this.Value--;
        }
    }
}
