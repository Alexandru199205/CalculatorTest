using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private float _firstValue = 0;
        private float _secondValue = 0;
        private float _result = 0;
        private  string _operators ="";
    
        public CalculatorForm()
        {
            InitializeComponent();
        }
// Allowing to introduce figures with the keyboard
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&  !char.IsDigit(e.KeyChar))
            { e.Handled = true; }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > 0))
            {
                e.Handled = true;
                }
            //if ((sender as TextBox).Text == "" && (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/'))
            //   {
            //    e.Handled = true;
            //}
            
            if (e.KeyChar == '+')
            {
                ButtonPlus_Click(sender as TextBox, e);
            }
            if (e.KeyChar == '-')
            {
                ButtonMinus_Click(sender as TextBox, e);
            }
            if (e.KeyChar == '*')
            {
                ButtonMultiply_Click(sender as TextBox, e);
            }
            if (e.KeyChar == '/')
            {
                ButtonDivide_Click(sender as TextBox, e);
            }
            if (e.KeyChar.ToString() =="08")
            {
                Backspacebutton_Click(sender as TextBox, e);
            }
            if (e.KeyChar.ToString() ==",")
            {
                ButtonComma_Click(sender as TextBox, e);
                // Keeping the cursor at the begining of the textbox.(After some code it goes at the end of the textbox)               
                textBox.Select(textBox.Text.Length, 0);
            }

            if (e.KeyChar == '%')
            {
                Percentbutton_Click(sender as TextBox, e);
            }
            if (e.KeyChar == (char)Keys.Return)
            {
                ButtonEqual_Click(sender as TextBox, e);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        // Method that helps introducing the numbers in the textbox (reduce duplicate code)

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }
        public void NumCheck(string num)
        {
            if (textBox.Text == "" )
            {
                textBox.Text = num;
            }
            else 
            {
                textBox.Text += num;
            }
        
        }


       // Adding the buttons in the textbox
        private void ButtonZero_Click(object sender, EventArgs e)
        {
            NumCheck("0");
        }

        private void ButtonOne_Click(object sender, EventArgs e)
        {
            NumCheck("1");
        }

        private void ButtonTwo_Click(object sender, EventArgs e)
        {
            NumCheck("2");
        }

        private void ButtonThree_Click(object sender, EventArgs e)
        {
            NumCheck("3");
        }

        private void ButtonFour_Click(object sender, EventArgs e)
        {

            NumCheck("4");
        }

        private void ButtonFive_Click(object sender, EventArgs e)
        {
            NumCheck("5");
        }

        private void ButtonSix_Click(object sender, EventArgs e)
        {
            NumCheck("6");
        }

        private void ButtonSeven_Click(object sender, EventArgs e)
        {
            NumCheck("7");
        }

        private void ButtonEight_Click(object sender, EventArgs e)
        {
            NumCheck("8");
        }

        private void ButtonNine_Click(object sender, EventArgs e)
        {
            NumCheck("9");
        }


        private void ButtonPlusMinus_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Contains('-'))
            {
               textBox.Text= textBox.Text.Trim('-');
            }
            else { textBox.Text = '-' + textBox.Text; }
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            if (!textBox.Text.Contains(','))
            {
                textBox.Text += ",";
            }
            else
            {
                textBox.Text = textBox.Text;

            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)

        {
            textBox.Clear();
            // The lines below prevent operating with remained, uncleared data in case the '
           // clear' button is pressed during an unfinished opperetion.
            _firstValue = 0;
            _secondValue = 0;
        }
        // Deleting unwanted figures from Textbox.
        private void Backspacebutton_Click(object sender, EventArgs e)
        {
            try
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
            catch (ArgumentOutOfRangeException)
            {

            }

        }
      // The action of operators
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            // Allowing to do multiple '+' opperations before hitting '='

            if (_firstValue != 0)
            {
               _firstValue += float.Parse(textBox.Text);
                textBox.Text = _firstValue.ToString();
             textBox.Clear();
            } 
            else
            {
                
                _firstValue = float.Parse(textBox.Text);

              textBox.Clear();
               _operators = "+";
            }
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
       
        {
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            // Allowing to do multiple '-' opperations before hitting '='
            if (_firstValue != 0)
            {
                _firstValue -= float.Parse(textBox.Text);
                textBox.Clear();
            }
            else

            {
                _firstValue = float.Parse(textBox.Text);
                textBox.Clear();
                _operators = "-";
            }
            }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            // Allowing to do multiple '*' opperations before hitting '='
            if (_firstValue != 0)
            {
                _firstValue *= float.Parse(textBox.Text);
                textBox.Clear();
            }
            else
            {
                _firstValue = float.Parse(textBox.Text);
                textBox.Clear();
                _operators = "*";
            }
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            // Allowing to do multiple '/' opperations before hitting '='
            if (_firstValue != 0)
            {
                _firstValue /= float.Parse(textBox.Text);
                textBox.Clear();
            }
            else
            {
                _firstValue = float.Parse(textBox.Text);
                textBox.Clear();
                _operators = "/";
            }
        }
         
        private void Percentbutton_Click(object sender, EventArgs e)
        {

            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            _firstValue = long.Parse(textBox.Text);
            textBox.Clear();
            _operators = "%";
        }
      // Bellow is the code responsible with returning the results ('=' button).
        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            switch (_operators)
            {

                case "+":
                    float.TryParse(textBox.Text, out _secondValue);
                    _result = _firstValue + _secondValue;
                   
                    break;
                case "-":

                    float.TryParse(textBox.Text, out _secondValue);
                    _result = _firstValue - _secondValue;
                
                    break;
                case "*":
                    float.TryParse(textBox.Text, out _secondValue);
                    _result = _firstValue * _secondValue;
                    break;
                case "/":
                    float.TryParse(textBox.Text, out _secondValue);
                    if (_secondValue == 0)
                    {
                        MessageBox.Show("you cannot devide to zero, please delete and insert another value");
                        return;
                    }
                    _result = _firstValue / _secondValue;
                    break;
                case "%":
                    float.TryParse(textBox.Text, out _secondValue);
                    _result = _firstValue % _secondValue;
                    break;
            }
            textBox.Text = _result.ToString();
            // The following line alows to continue opperating (if wanted) after pressing '='   
            _firstValue = 0;
        }

       
    }

}
