using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakingWords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] input;
        char[] chars;
        bool correctInput;

        private void button1_Click(object sender, EventArgs e)
        {
            CheckInput();

            if (correctInput)
            {
                MakeWords wordsMaker = new MakeWords(chars);
                wordsMaker.CreateWords((int)numericUpDown1.Value);
                richTextBox1.Text = wordsMaker.output;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckInput();
            
            if (correctInput)
            {
                MakeWords wordsMaker = new MakeWords(chars);
                wordsMaker.ReadFile(Application.StartupPath + @"\word_rus.txt");
                wordsMaker.CreateRealWords((int)numericUpDown1.Value);
                richTextBox1.Text = wordsMaker.output;
            }
        }

        private void CheckInput()
        {
            input = textBox1.Text.Split(' ');
            chars = new char[input.Length];
            correctInput = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length == 1)
                {
                    chars[i] = input[i][0];
                }
                else
                {
                    correctInput = false;
                    MessageBox.Show("Неверно введены буквы!\nИх необходимо разделять пробелом.");
                }
            }
            if ((int)numericUpDown1.Value > chars.Length)
            {
                correctInput = false;
                MessageBox.Show("Неверная длина слова!\nДлина слова должна быть не больше количества букв.");
            }
            if ((int)numericUpDown1.Value != numericUpDown1.Value)
            {
                MessageBox.Show("Длина слова должна быть целым числом!\nЗначение будет округлено.");
                numericUpDown1.Value = (int)numericUpDown1.Value;
            }
        }
    }
}
