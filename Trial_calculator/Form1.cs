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
    public partial class Form1 : Form
    {

        Calculator calc;
        public Form1()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.DidUpdateValue += calc_DidUpdate;
            calc.InputError += calc_Error;
            calc.CalculationError += calc_Error;
        }

        private void calc_Error(object sender, string e)
        {
            MessageBox.Show(e, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void calc_DidUpdate(Calculator sender, double value, int precision)
        {
            if (precision > 0 )
                textBox1.Text = String.Format("{0:F" + precision + "}", value);
            else
                textBox1.Text = $"{value}";
        }

        private void button_Click(object sender, EventArgs e)
        {

            
            string text = (sender as Button).Text;
            string name = (sender as Button).Name;
            object tag = (sender as Button).Tag;
            //MessageBox.Show($"{name} : {text}, {tag}");

            

            int digit;
            if (int.TryParse(text, out digit))
            {
                 
                calc.AddDigit(digit);
            }
            else
            {
                switch (tag)
                {
                    case "decimal":
                        calc.AddDecimalPoint();
                        break;
                    case "addition":
                        calc.AddOperation(Operation.Add);
                        break;
                    case "substraction":
                        calc.AddOperation(Operation.Sub);
                        break;
                    case "multiplication":
                        calc.AddOperation(Operation.Mul);
                        break;
                    case "division":
                        calc.AddOperation(Operation.Div);
                        break;
                    case "clear":
                        calc.Clear();
                        break;
                    case "evaluate":
                        calc.Compute();
                        break;
                    case "plusandminus":
                        calc.ClearSimbol();
                        break;
                }
            }
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 3;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 1;
        }
    }
}