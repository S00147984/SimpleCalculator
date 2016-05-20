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
        public MainWindow()
        {
            InitializeComponent();

            if (tbxSum.Text == "")
            {
                btnDiv.IsEnabled = false;
                btnMult.IsEnabled = false;
            }
        }

        protected void btnSumClick(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            int pos = tbxSum.Text.Length;

            if (pos == 0 && myButton.Content.ToString() == "BK")
            {
                btnDiv.IsEnabled = false;
                btnMult.IsEnabled = false;
            }

            btnDiv.IsEnabled = true;
            btnMult.IsEnabled = true;

            if (pos > 0)
            {

                if ((tbxSum.Text[pos - 1] == '/' || tbxSum.Text[pos - 1] == '*') &&
                    (myButton.Content.ToString() == "/" || myButton.Content.ToString() == "*"))
                {
                    int location = tbxSum.Text.Length - 1;
                    tbxSum.Text = tbxSum.Text.Remove(location, 1);
                }

                else if(myButton.Content.ToString() == "(" && tbxSum.Text[pos - 1] != '-' &&
                    tbxSum.Text[pos - 1] != '+' && tbxSum.Text[pos - 1] != '/' 
                    && tbxSum.Text[pos - 1] != '*')
                {
                    string theString = tbxSum.Text;
                    var aStringBuilder = new StringBuilder(theString);
                    aStringBuilder.Remove(pos, 0);
                    aStringBuilder.Insert(pos, "*");
                    theString = aStringBuilder.ToString();
                    tbxSum.Text = theString;
                }

            }

            if (myButton.Content.ToString() == "=")
            {
                DataTable dt = new DataTable();
                string s = tbxSum.Text;

                try
                {
                    var v = dt.Compute(s, "");
                    tbkSum.Text = s + "=" + v.ToString();
                    tbxSum.Text = v.ToString();
                }
                    
                catch
                {
                    MessageBox.Show("Invalid Sum!");
                }
            }

            else if (myButton.Content.ToString() == "CE")
            {
                tbxSum.Text = String.Empty;
                tbkSum.Text = String.Empty;
                btnDiv.IsEnabled = false;
                btnMult.IsEnabled = false;
            }


            else if (myButton.Content.ToString() == "BK" && pos > 0)
            {
                string theString = tbxSum.Text;
                var aStringBuilder = new StringBuilder(theString);
                aStringBuilder.Remove(pos - 1, 1);
                theString = aStringBuilder.ToString();
                tbxSum.Text = theString;

                if (tbxSum.Text.Length == 0)
                {
                    btnDiv.IsEnabled = false;
                    btnMult.IsEnabled = false;
                }
            }

            else if (myButton.Content.ToString() == "BK" && pos == 0)
            {
                tbxSum.Text = String.Empty;
                btnDiv.IsEnabled = false;
                btnMult.IsEnabled = false;
            }

            else
            {
                tbxSum.Text += myButton.Content.ToString();
                tbxSum.Focus();
                tbxSum.SelectionStart = tbxSum.Text.Length;
            }      
            
        }

    }
}
