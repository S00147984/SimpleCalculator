using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calcamaloator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double value1;
        double value2;
        double result;
        string operater;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected void btnNumClick(object sender, EventArgs e)
        {
            var myButton = (Button)sender;

            tbxSum.Text += myButton.Content.ToString();
        }

        protected void btnOperatorClick(object sender, EventArgs e)
        {
            if (tbxSum.Text != "")
            {
                value1 = Convert.ToDouble(tbxSum.Text);
                tbxSum.Text = "";
            }

            var myButton = (Button)sender;
            operater = myButton.Content.ToString();

            if (value1 == 0 && operater == "-")
            {
                tbxSum.Text = operater;
            }

            if (value1 != 0)
            {
                tbkSum.Text = value1.ToString() + ' ' + operater;
            }

        }

        protected void btnEquaClick(object sender, EventArgs e)
        {
            if (value1 == 0)
            {
                tbxSum.Text = "";
                tbkSum.Text = value1.ToString() + ' ' + '=' + ' ' + value1.ToString();
            }

            else
            {
                value2 = Convert.ToDouble(tbxSum.Text);
                tbxSum.Text = " ";

                if (operater == "+")
                {
                    result = value1 + value2;
                }

                if (operater == "-")
                {
                    result = value1 - value2;
                }

                if (operater == "x")
                {
                    result = value1 * value2;
                }

                if (operater == "/")
                {
                    result = value1 / value2;
                }

                tbkSum.Text = value1.ToString() + ' ' + operater + ' ' 
                    + value2.ToString() + ' ' + '=' + ' ' + result.ToString();
                tbxSum.Text = "";

                value1 = result;
            }
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            tbxSum.Text = "";
            tbkSum.Text = "";
            value1 = 0;
            value2 = 0;
            operater = "";
        }

        private void btnPerc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
