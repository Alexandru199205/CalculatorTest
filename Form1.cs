using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private string _operators = "";
        private int zeroval = 0;
        private int oneValue = 1;


        public CalculatorForm()
        {
            InitializeComponent();
        }
        // Allowing to introduce figures with the keyboard
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.Focus();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > 0))
            {
                e.Handled = true;
            }
            switch (e.KeyChar)
            {
                case '+':
                    ExecutePlus();
                    break;
                case '-':
                    ExecuteMinus();
                    break;
                case '*':
                    ExecuteMuliply();
                    break;
                case '/':
                    ExecuteDivide();
                    break;
                case ',':
                    Comma();
                    // Keeping the cursor at the begining of the textbox.(After some code it goes at the end of the textbox)               
                    textBox.Select(textBox.Text.Length, 0);
                    break;
                default:
                    break;
            }

            if (e.KeyChar.ToString() == "08")
            {
                BackSpace();
            }
            if (e.KeyChar == '%')
            {
                ExecutePercentage();
            }
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == '=')
            {
                ExecuteEqual();
                textBox.Select(textBox.Text.Length, 0);
            }

        }
        // Method that helps introducing the numbers in the textbox (reduce duplicate code)
        public void NumCheck(string num)
        {
            if (textBox.Text == "")
            {
                textBox.Text = num;
            }

            else
            {
                textBox.Text += num;
            }

        }
        // Adding the buttons in the textbox
        private void NUmberButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            NumCheck(button.Tag.ToString());
        }

        private void ButtonPlusMinus_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Contains('-'))
            {
                textBox.Text = textBox.Text.Trim('-');
            }
            else { textBox.Text = '-' + textBox.Text; }
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            Comma();
        }

        private void ButtonClear_Click(object sender, EventArgs e)

        {
            textBox.Clear();
            labeldescription.Text = "";
            textBox.Select();
        
        //textBox2.Clear();
        // The lines below prevent operating with remained, uncleared data in case the '
        // clear' button is pressed during an unfinished opperetion.
        _firstValue = 0;
            _secondValue = 0;
        }
        // Deleting unwanted figures from Textbox.
        private void Backspacebutton_Click(object sender, EventArgs e)
        {
            BackSpace();
        }
        // The action of operators
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            ExecutePlus();

        }

        private void ButtonMinus_Click(object sender, EventArgs e)

        {
            ExecuteMinus();

        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            ExecuteMuliply();

        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            ExecuteDivide();

        }

        private void Percentbutton_Click(object sender, EventArgs e)
        {

            ExecutePercentage();
        }

        // Bellow is the code responsible with returning the results ('=' button).
        private void ButtonEqual_Click(object sender, EventArgs e)

        {
            ExecuteEqual();
        }

        // It helps to see all the data in a "multisteps" operation.


        private void labeldescription_Click()
        {
            labeldescription.Text = _firstValue + _operators;

        }
        private void Multioperators(string opera)
        {
           
            if (_firstValue != 0 && _operators != opera)
            {
                switch (_operators)
                {
                    case "+":
                       //This condition allow user to change opperators in case the wrong one was introduced.
                        if (textBox.Text == "")
                        {
                            textBox.Text =zeroval.ToString();
                        }
                        _firstValue += float.Parse(textBox.Text);
                        break;
                    case "-":
                        if (textBox.Text == "")
                        {
                            textBox.Text = zeroval.ToString();
                        }
                        _firstValue -= float.Parse(textBox.Text);
                        break;
                    case "*":
                        if (textBox.Text == "")
                        {
                            textBox.Text = oneValue.ToString();
                        }
                        _firstValue *= float.Parse(textBox.Text);
                        break;
                    case "/":

                        if (textBox.Text == "")
                        {
                            textBox.Text = oneValue.ToString();
                        }
                        _firstValue /= float.Parse(textBox.Text);
                        break;
                    case "%":

                        if (textBox.Text == "")
                        {
                            textBox.Text = oneValue.ToString();
                        }
                        _firstValue %= float.Parse(textBox.Text);
                        break;
                    default:
                        break;

                }
                textBox.Clear();
                _operators = opera;
                labeldescription_Click();
            }
        }
        private void ExecutePlus()
        {
            Multioperators("+");

            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }

            else if (_firstValue != 0)
            {
                _firstValue += float.Parse(textBox.Text);
                labeldescription_Click();
                textBox.Clear();
            }

            else
            {
                _firstValue += float.Parse(textBox.Text);
                _operators = "+";
                labeldescription_Click();
                textBox.Clear();

            }

        }
        private void ExecuteMinus()
        {
            Multioperators("-");
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }

            else if (_firstValue != 0)
            {
                _firstValue -= float.Parse(textBox.Text);
                labeldescription_Click();
                textBox.Clear();
            }
            else

            {
                _firstValue = float.Parse(textBox.Text);
                _operators = "-";
                labeldescription_Click();
                textBox.Clear();
            }
        }
        private void ExecuteMuliply()
        {
            Multioperators("*");
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            else if (_firstValue != 0)
            {
                _firstValue *= float.Parse(textBox.Text);
                labeldescription_Click();
                textBox.Clear();
            }
            else

            {
                _firstValue = float.Parse(textBox.Text);
                _operators = "*";
                labeldescription_Click();
                textBox.Clear();
            }
        }
        private void ExecuteDivide()
        {
            Multioperators("/");
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            else if (_firstValue != 0)
            {
                _firstValue /= float.Parse(textBox.Text);
                labeldescription_Click();
                //textBox2_TextChanged();
                textBox.Clear();
            }
            else

            {
                _firstValue = float.Parse(textBox.Text);
                _operators = "/";
                labeldescription_Click();
                textBox.Clear();
            }
        }
        private void ExecutePercentage()
        {
            //Preventing the crash if user enter operators on an empty box.
            if (textBox.Text == "")
            {
                return;
            }
            labeldescription_Click();
            _operators = "%";
            _firstValue = long.Parse(textBox.Text);
            textBox.Clear();
        }
        private void BackSpace()
        {
            if(textBox.Text.Length>0)
           
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            
        }
        private void ExecuteEqual()


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
            labeldescription.Text = _firstValue + _operators + _secondValue + "=" + _result.ToString();

            // The following line alows to continue opperating (if wanted) after pressing '='   
            _firstValue = 0;
        }
        private void Comma()
        {
            if (!textBox.Text.Contains(','))
            {
           CultureInfo.CurrentCulture = new CultureInfo("en-US");

                textBox.Text += ",";
            }
            else
            {
                textBox.Text = textBox.Text;

            }
        }
    }
}


