using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_ED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        string[] bin_ASCII = {"01100001",
"01100010",
"01100011",
"01100100",
"01100101",
"01100110",
"01100111",
"01101000",
"01101001",
"01101010",
"01101011",
"01101100",
"01101101",
"01101110",
"01101111",
"01110000",
"01110001",
"01110010",
"01110011",
"01110100",
"01110101",
"01110110",
"01110111",
"01111000",
"01111001",
"01111010",
"01000001",
"01000010",
"01000011",
"01000100",
"01000101",
"01000110",
"01000111",
"01001000",
"01001001",
"01001010",
"01001011",
"01001100",
"01001101",
"01001110",
"01001111",
"01010000",
"01010001",
"01010010",
"01010011",
"01010100",
"01010101",
"01010110",
"01010111",
"01011000",
"01011001",
"01011010",
"00110001",
"00110010",
"00110011",
"00110100",
"00110101",
"00110110",
"00110111",
"00111000",
"00111001",
"00110000",
"00101110",
"00101100",
"00100000",
"00100001",
"00111111",
"00101101",
"00101000",
"00101001",};

        string char_ASCII = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890., !?-()";

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.Text;
            Encoding ascii = Encoding.ASCII;
            string s_ascii = "";
            Byte[] encodedBytes = ascii.GetBytes(s);
            richTextBox2.Text = "";
            bool flag = true;
            for (int i = 0; i < s.Length; i++)
            {
                flag = true;
                for (int j = 0; j < char_ASCII.Length; j++)
                {
                    if (s[i].Equals(char_ASCII[j]))
                    {
                        richTextBox2.Text += bin_ASCII[j] + "\n";
                        s_ascii += bin_ASCII[j];

                        flag = false;
                        break;
                    }

                }
                if (flag)
                {
                    MessageBox.Show("Символ '" + s[i] + "' не найдкно в таблиці!", "Error", MessageBoxButtons.OK);
                    richTextBox2.Text += "Символ '" + s[i] + "' не найдкно в таблиці!\n";

                }
            }


            StreamWriter sw = new StreamWriter("навчаючі пари.txt");
            int n = Convert.ToInt32(textBox__n.Text);
            int N = Convert.ToInt32(textBox_N.Text);
            while (true)
            {
                if (s_ascii.Length / (1.0 * n * N) == Math.Round(s_ascii.Length / (1.0 * n * N))) break;
                s_ascii += "0";
            }
            sw.WriteLine("Кількість навчаючих пар: " + (s_ascii.Length / (1.0 * n * N)));
            string temps = "";
            for (int i = 0; i < s_ascii.Length; )
            {
                for (int j = 0; j < N; j++)
                {
                    temps = "x" + j + " = ";
                    for (int k = 0; k < n; k++, i++)
                        temps += s_ascii[i];
                    sw.WriteLine(temps);
                }



            }
            sw.Close();

        }
    }
}
