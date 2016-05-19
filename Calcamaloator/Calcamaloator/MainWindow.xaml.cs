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
using System.Data;


namespace Calcamaloator
{
    public partial class MainWindow : Window
    {
        double lastGoodValue = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        protected void btnSumClick(object sender, EventArgs e)
        {
            var myButton = (Button)sender;

            if (myButton.Content.ToString() == "=")
            {

                DataTable dt = new DataTable();
                string s = tbxSum.Text;

                if (s.Contains("("))
                {
                    s = s.Replace("(", "*(");
                }

                try
                {
                    var v = dt.Compute(s, "");
                    tbkSum.Text = s + "=" + v.ToString();
                    lastGoodValue = Convert.ToDouble(v);
                    tbxSum.Text = v.ToString();
                }
                    
                catch
                {
                    tbxSum.Text = lastGoodValue.ToString();
                    
                    MessageBox.Show("Invalid Sum, reset to previous valid result");
                }
            }

            else if (myButton.Content.ToString() == "CE")
            {
                tbxSum.Text = String.Empty;
                tbkSum.Text = String.Empty;
                lastGoodValue = 0;
            }

            else
            {
                tbxSum.Text += myButton.Content.ToString();
            }      
            
        }

    }
}
