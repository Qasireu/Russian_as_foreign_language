using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;



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

        private void button1_Click(object sender, EventArgs e) // Кнопка "Начать"
        {
            try
            {                
                Task_logic.TL_Loader(); //Загружает файл с заданиями
                Task_logic.line_sequnce_index=0; //указывает начало массива номеров строк lines_sequence
                Task_logic.CT_Line = Task_logic.lines_sequence[Task_logic.line_sequnce_index];
                Task_logic.Task_Answer_gen(Task_logic.CT_Line); // Формируем задание из текущеий строки текстового файла
                int count = 0; //счётчик кнопок
                List<System.Windows.Forms.Button> buttonList = new List<System.Windows.Forms.Button>();
                foreach (var button in flowLayoutPanel1.Controls.OfType<System.Windows.Forms.Button>()) //Добавляем кнопки в список
                {
                    buttonList.Add(button);
                    count++;
                }
                for (int i = 0; i < count; i++)
                {
                    if (Task_logic.wordCount > i) //Сравниваем количество кнопок и слов в задании
                    {
                        buttonList[i].Text = Task_logic.Answer_to_buttons[i];
                        buttonList[i].Visible = true;
                        buttonList[i].Enabled = true;
                    }
                    else //Оставшиеся кнопки деактивируем и выключаем
                    {
                        buttonList[i].Visible = false;
                        buttonList[i].Enabled = false;
                    }
                }
                // Переключаем режимы видимости элеентов интерфейса и формируем все варианты представления заданий
                label4.Enabled = false;
                label4.Visible = false;
                label5.Enabled = false;
                label5.Visible = false;
                button1.Visible = false;
                button1.Enabled = false;
                button2.Visible = false;
                button2.Enabled = false;
                button3.Visible = true;
                button3.Enabled = true;
                button4.Visible = true;
                button4.Enabled = true;
                button5.Visible = false;
                button5.Enabled = false;
                button6.Visible = true;
                button6.Enabled = true;
                button21.Visible = true;
                button21.Enabled = true;
                button22.Visible = true;
                button22.Enabled = true;
                label1.Enabled = true;
                label1.Visible = true;
                textBox1.Enabled = true;
                textBox1.Visible = true;
                textBox1.Clear();
                textBox1.BackColor = Color.White;
                label8.Enabled = true;
                label8.Visible = true;
                flowLayoutPanel1.Enabled = true; //активация панели с кнопками-словами
                flowLayoutPanel1.Visible = true; //активация панели с кнопками-словами
                flowLayoutPanel2.Enabled = false;
                flowLayoutPanel2.Visible = false;
                label2.Text = Task_logic.current_task_LINE.Substring(0, Task_logic.startIndex - 1);
                label3.Text = Task_logic.current_task_LINE.Substring(Task_logic.endIndex + 1);
                label6.Text = Task_logic.current_task_LINE.Substring(0, Task_logic.startIndex - 1);
                label7.Text = Task_logic.current_task_LINE.Substring(Task_logic.endIndex + 1);
                for (int i = 0; i < Task_logic.task_words.Length; i++)
                {
                    comboBox1.Items.Add(Task_logic.task_words[i]);
                }
                if (Task_logic.if_Test == true && Task_logic.button3_clicked == false)
                {
                    button21.Text = "Пропустить";
                }
                if (Task_logic.if_Test == true && Task_logic.button3_clicked == true)
                { button21.Text = "Следующее"; } 
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GetAllButtons()
        {

        }

        private void button2_Click(object sender, EventArgs e) //Кнопка "Пройти обучение"
        {
            Task_logic.if_Test = false;
            button2.Enabled = false;
            button2.Visible = false;
            button5.Enabled = false;
            button5.Visible = false;
            button1.Enabled = true;
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e) //Кнопка"Готово"
        {
            try
            {
                Task_logic.BUTTON3_clck(true);
                if(flowLayoutPanel1.Enabled==true)
                {
                   Task_logic.User_answer = textBox1.Text;
                }
                else if(flowLayoutPanel2.Enabled==true) 
                {
                   Task_logic.User_answer = label2.Text + " " + comboBox1.Text + label3.Text + " ";
                }
                else if (flowLayoutPanel4.Enabled == true)
                {
                   Task_logic.User_answer = label6.Text + " " + textBox2.Text  + label7.Text + " ";
                }
                if (Task_logic.User_answer == Task_logic.Answer + " ")
                {
                    
                     
                    Task_logic.if_write_answer = true;
                    button21.BackColor = Color.DarkSeaGreen;
                    button21.Text = "Следующее";
                    button3.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button22.Enabled = false;
                    textBox1.BackColor = Color.LightGreen;
                    if(flowLayoutPanel2.Enabled == true&& Task_logic.if_Test == false)
                    {
                        textBox1.Text = Task_logic.User_answer + "\n Комментарий о грамматике.";
                    }
                    else if(flowLayoutPanel4.Enabled==true&& Task_logic.if_Test == false)
                    {
                       textBox1.Text = Task_logic.User_answer + "\n Комментарий о грамматике.";
                    }
                        //button21.Enabled = true;
                        //button21.Visible = true;
                        button3.Visible = false;
                        button3.Enabled = false;
                   }
                   else
                    {
                        textBox1.BackColor = Color.Red;
                        if (Task_logic.if_Test == false)
                        { 
                        textBox1.Text = textBox1.Text +"Правильный вариант: "+Task_logic.Answer + "\n Комментарий о грамматике.";                            
                        }
                    }                
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void button4_Click(object sender, EventArgs e) //Кнопка "Очистить" нужна для очистки Textbox1
        {
            textBox1.Clear();
            textBox1.BackColor= Color.White;
        }
        private void button5_Click(object sender, EventArgs e) // Кнопка "Пройти тест"
        {
            Task_logic.if_Test = true;
            Task_logic.Test_score_rate(100);
            button2.Enabled = false;
            button2.Visible = false;
            button5.Enabled = false;
            button5.Visible = false;
            button1.Enabled = true;
            button1.Visible = true;
        }
        private void button6_Click(object sender, EventArgs e)// Кнопка "Проще"
        {
            try
            {
                if(Task_logic.if_Test == true&&Task_logic.button6_clicked==false) 
                {
                    Task_logic.BUTTON6_clck(true);
                    Task_logic.Test_score -= 2; 
                }
                    if (flowLayoutPanel1.Enabled == true)
                    {
                    //button4.Enabled= false;
                    //button4.Visible= false;
                    textBox1.Clear();
                    label8.Enabled = false;
                    label8.Visible = false;
                    flowLayoutPanel1.Enabled = false;
                    flowLayoutPanel1.Visible = false;
                    label9.Enabled = true;
                    label9.Visible = true;
                    flowLayoutPanel2.Enabled = true;
                    flowLayoutPanel2.Visible = true;
                    label10.Enabled = false;
                    label10.Visible = false;
                    flowLayoutPanel4.Enabled = false;
                    flowLayoutPanel4.Visible = false;                    
                    }
                    else if (flowLayoutPanel2.Enabled == true)
                        {
                        comboBox1.Text = string.Empty;
                        label8.Enabled = false;
                        label8.Visible = false;
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel1.Visible = false;
                        label9.Enabled = false;
                        label9.Visible= false;
                        flowLayoutPanel2.Enabled = false;
                        flowLayoutPanel2.Visible = false;
                        label10.Enabled = true;
                        label10.Visible = true;
                        flowLayoutPanel4.Enabled = true;
                        flowLayoutPanel4.Visible = true;
                    }                
            }
            catch (Exception)
            {
                throw;
            }
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
            textBox1.Text = textBox1.Text + button9.Text + " ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button10.Text + " ";
        }


        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button11.Text + " ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button12.Text + " ";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button13.Text + " ";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button14.Text + " ";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button15.Text + " ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button16.Text + " ";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button17.Text + " ";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button18.Text + " ";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button19.Text + " ";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button20.Text + " ";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e) //Кнопка "Пропустить"/"Следующее"
        {
            try
            {
                if (Task_logic.if_Test == true && Task_logic.button3_clicked == false&& Task_logic.button6_clicked == false)
                {
                    Task_logic.Test_score -= 10;
                }
                else if (Task_logic.if_Test == true && Task_logic.button3_clicked == false && Task_logic.button6_clicked == true)
                {
                    Task_logic.Test_score -= 8;
                }
                Task_logic.line_sequnce_index++;
                    if (Task_logic.line_sequnce_index >= Task_logic.Lines_count)
                    {
                        if (Task_logic.if_Test == true)
                        {
                            textBox1.Clear();
                            textBox1.BackColor = Color.Green;
                            textBox1.Text = textBox1.Text + "\nКонец теста.\n Вы набрали баллов: " + Task_logic.Test_score + " из 100";
                        flowLayoutPanel2.Enabled = false;
                        flowLayoutPanel2.Visible = false;
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel1.Visible = false;
                        label9.Visible = false;
                        label8.Visible = false;
                        button3.Enabled = false;
                        button3.Visible = false;
                        button4.Enabled = false;
                        button4.Visible = false;
                        button6.Enabled = false;
                        button6.Visible = false;
                        button21.Enabled = false;
                        button21.Visible = false;
                        button22.Enabled = false;
                        button22.Visible = false;
                        label5.Visible = true;
                        label5.Enabled = true;
                        button1.Enabled = false;
                        button1.Visible = false;
                        button2.Enabled = true;
                        button2.Visible = true;
                        button5.Enabled = true;
                        button5.Visible = true;

                    }
                        else
                        {
                            textBox1.Clear();
                            textBox1.BackColor = Color.Green;
                            textBox1.Text = "Конец программы обучения. Спасибо что воспользовались нашей программой." +
                                "Тренируйтесь и повторяйте эти задания для лучшего усвоения материала";
                            flowLayoutPanel2.Enabled = false;
                            flowLayoutPanel2.Visible = false;
                            flowLayoutPanel1.Enabled = false;
                            flowLayoutPanel1.Visible = false;
                            label9.Visible = false;
                            label8.Visible = false;
                            button3.Enabled = false;
                            button3.Visible = false;
                            button4.Enabled = false;
                            button4.Visible = false;
                            button6.Enabled = false;
                            button6.Visible = false;
                            button21.Enabled = false;
                            button21.Visible = false;
                            button22.Enabled = false;
                            button22.Visible = false;
                            label5.Visible = true;
                            label5.Enabled = true;
                            button1.Enabled = false;
                            button1.Visible = false;
                            button2.Enabled = true;
                            button2.Visible = true;
                            button5.Enabled = true;
                            button5.Visible = true;

                        }
                    }
                    else
                    {
                        Task_logic.BUTTON6_clck(false);
                        Task_logic.CT_Line = Task_logic.lines_sequence[Task_logic.line_sequnce_index];
                        Task_logic.Task_Answer_gen(Task_logic.CT_Line);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.BackColor = Color.White;
                        button21.Text = "Пропустить";
                        button21.BackColor = Color.PaleGoldenrod;
                    for (int i = 0; i < Task_logic.task_words.Length; i++)
                        {
                            comboBox1.Items.Clear();
                            comboBox1.ResetText();
                        }

                        int count = 0;
                        List<System.Windows.Forms.Button> buttonList = new List<System.Windows.Forms.Button>();
                        foreach (var button in flowLayoutPanel1.Controls.OfType<System.Windows.Forms.Button>()) //Добавляем кнопки в список
                        {
                            buttonList.Add(button);
                            count++;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            if (Task_logic.wordCount > i) //Сравниваем количество кнопок и слов в задании
                            {
                                buttonList[i].Text = Task_logic.Answer_to_buttons[i];
                                buttonList[i].Visible = true;
                                buttonList[i].Enabled = true;
                            }
                            else //Оставшиеся кнопки деактивируем и выключаем
                            {
                                buttonList[i].Visible = false;
                                buttonList[i].Enabled = false;
                            }
                        }
                        button1.Visible = false;
                        button1.Enabled = false;
                        button2.Visible = false;
                        button2.Enabled = false;
                        button3.Visible = true;
                        button3.Enabled = true;
                        button4.Visible = true;
                        button4.Enabled = true;
                        button6.Visible = true;
                        button6.Enabled = true;
                        button22.Visible = true;
                        button22.Enabled = true;
                        label1.Enabled = true;
                        label1.Visible = true;
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label8.Enabled = true;
                        label8.Visible = true;
                        label9.Enabled = false;
                        label9.Visible = false;
                        flowLayoutPanel1.Enabled = true;
                        flowLayoutPanel1.Visible = true;
                        flowLayoutPanel2.Enabled = false;
                        flowLayoutPanel2.Visible = false;
                        flowLayoutPanel4.Enabled = false;
                        flowLayoutPanel4.Visible = false;
                        label10.Enabled = false;
                        label10.Visible = false;
                        label2.Text = Task_logic.current_task_LINE.Substring(0, Task_logic.startIndex - 1);
                        label3.Text = Task_logic.current_task_LINE.Substring(Task_logic.endIndex + 1);
                        label6.Text = Task_logic.current_task_LINE.Substring(0, Task_logic.startIndex - 1);
                        label7.Text = Task_logic.current_task_LINE.Substring(Task_logic.endIndex + 1);
                        for (int i = 0; i < Task_logic.task_words.Length; i++)
                        {
                            comboBox1.Items.Add(Task_logic.task_words[i]);
                        }
                        //button21.Visible = false;
                        //button21.Enabled = false;
                    }
                Task_logic.BUTTON3_clck(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e) //Кнопка "Сложнее"
        {
            try
            {                
                if (flowLayoutPanel4.Enabled == true)
                {
                    textBox2.Clear();
                    flowLayoutPanel4.Enabled = false;
                    flowLayoutPanel4.Visible = false;
                    label8.Enabled = false;
                    label8.Visible = false;
                    flowLayoutPanel1.Enabled = false;
                    flowLayoutPanel1.Visible = false;
                    label9.Enabled = true;
                    label9.Visible = true;
                    flowLayoutPanel2.Enabled = true;
                    flowLayoutPanel2.Visible = true;
                    label10.Enabled = false;
                    label10.Visible = false;
                    
                }
                else if (flowLayoutPanel2.Enabled == true)
                {
                    comboBox1.Text = string.Empty;
                    label8.Enabled = true;
                    label8.Visible = true;
                    flowLayoutPanel1.Enabled = true;
                    flowLayoutPanel1.Visible = true;
                    label9.Enabled = false;
                    label9.Visible = false;
                    flowLayoutPanel2.Enabled = false;
                    flowLayoutPanel2.Visible = false;
                    label10.Enabled = false;
                    label10.Visible = false;
                    flowLayoutPanel4.Enabled = false;
                    flowLayoutPanel4.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
