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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanel1.Enabled = true;
                flowLayoutPanel1.Visible = true;
                string file_Path = @"C:\Users\User\source\repos\WindowsFormsApp1\WindowsFormsApp1\Base.txt"; // путь к файлу
                using (StreamReader sr = new StreamReader(file_Path))
                {
                    string text = sr.ReadToEnd();
                    sr.Close();
                    // Разбиваем текст на массив слов
                    string[] words = text.Split(' ');
                    int wordCount = words.Length;
                    //MessageBox.Show("Количество слов в тексте: " + wordCount);
                    int count = 0;
                    List<System.Windows.Forms.Button> buttonList = new List<System.Windows.Forms.Button>();
                    foreach (var button in flowLayoutPanel1.Controls.OfType<System.Windows.Forms.Button>()) //Добавляем кнопки в список
                    {
                        buttonList.Add(button);
                        count++;
                    }
                    for (int i = 0; i < count; i++) 
                    {
                        if (wordCount > i) //Сравниваем количество кнопок и слов в задании
                        {
                            buttonList[i].Text = words[i];
                            buttonList[i].Visible = true;
                            buttonList[i].Enabled = true;
                        }
                        else //Оставшиеся кнопки деактивируем и выключаем
                        { 
                            buttonList[i].Visible = false;
                            buttonList[i].Enabled = false;
                        }
                    }
                    //MessageBox.Show("Number of buttons: " + count);
                    //MessageBox.Show("button " + buttonList[3].Text);
                    }
                button1.Enabled = false;
                button1.Visible = false;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void GetAllButtons()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button2.Text + " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button3.Text + " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button4.Text + " ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button5.Text + " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button6.Text + " ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button7.Text + " ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button8.Text + " ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string file_Path = @"C:\Users\User\source\repos\WindowsFormsApp1\WindowsFormsApp1\Answer.txt"; // путь к файлу
                using (StreamReader ar = new StreamReader(file_Path))
                {
                    string Answ = ar.ReadToEnd();
                    ar.Close();
                    string[] Answer = Answ.Split(' ');
                    string textBoxText = textBox1.Text;
                    if (textBoxText == Answ)
                    {
                        MessageBox.Show("Correct " + Answ);
                        
                      

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
