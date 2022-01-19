using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSin0WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            int b9 = Base10ToBase9(int.Parse(textBox1.Text));
            int b9sin0 = Base9ToBase9Sin0(b9);
            Base9TextBox.Text = b9.ToString();
            Base9Sin0TextBox.Text = b9sin0.ToString();
        }

        private int Base10ToBase9(int b10)
        {
            var b = 9;
            var resultStr = "";
            int lastExponent = 0;
            while (true)
            {
                if (b10 < b)
                {
                    resultStr += b10.ToString().PadLeft(lastExponent, '0');
                    break;
                }
                var exponent = (int)Math.Log(b10, b);
                int d = b10 / (int)(Math.Pow(b, exponent));
                if (lastExponent == 0)
                    resultStr += d;
                else
                    resultStr += d.ToString().PadLeft(lastExponent - exponent, '0');
                lastExponent = exponent;
                b10 = b10 - d * (int)Math.Pow(b, exponent);
            }

            return int.Parse(resultStr);
        }

        public int Base9ToBase9Sin0(int b9)
        {
            var l = b9.ToString().AsEnumerable().Select(c => c - '0').ToArray();
            bool carry = false;
            for (var i = l.Length - 1; i >= 0; i--)
            {
                bool nextCarry = false;
                if (l[i] == 0)
                {
                    l[i] = 9;
                    nextCarry = true;
                }
                if (carry)
                    l[i]--;
                carry = nextCarry;
            }
            return int.Parse(string.Concat(l));
        }

    }
}
