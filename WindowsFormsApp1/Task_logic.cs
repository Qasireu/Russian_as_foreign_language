using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    internal static class Task_logic
    {
        public static bool if_write_answer;
        public static bool button6_clicked;
        public static bool button3_clicked;
        public static bool if_Test; //переменная указывает если включен режим тестирования
        public static int Test_score; // В режиме тестирования считате баллы
        public static int Lines_count;
        public static int random_line_number;
        public static int CT_Line;
        public static int startIndex;
        public static int endIndex;
        public static int wordCount;
        public static int line_sequnce_index;
        public static int[] lines_sequence;
        public static int[] Arr_tasklines;
        public static string file_Path ;
        public static string[] lines;
        public static string current_task_LINE;
        public static string temp_task;
        public static string[] task_words;
        public static string Answer;
        public static string[] Answer_to_buttons;
        public static string User_answer;

        public static void BUTTON3_clck(bool clck)
        {
            button3_clicked = clck;
        }
        public static void BUTTON6_clck (bool clck)
        {
            button6_clicked = clck;
        }
        public static void Test(bool Test) 
        {
            if_Test = Test;
        }
        public static void Test_score_rate( int score )
        {
            Test_score = score;
        }
        public static void TL_Loader(string file_Path = @"Answer.txt")
        {
            
            using (StreamReader sr = new StreamReader(file_Path))
            { lines = sr.ReadToEnd().Split('\n').ToArray(); } //Читаем файл с заданиями, разбиваем его на строки и записываем в массив.
            Lines_count = lines.Count(); //Число строк из файла с заданиями. Одна строка - одно задание.
            lines_sequence = Enumerable.Range(0, Lines_count).ToArray(); // массив номеров строк отвечает за последовательость строк
            FisherYatesShuffle(lines_sequence); //Перемешиваем номера строк в случайном порядке. Получаем возможность управлять вызовом строк имеющих случайный порядок.
            
        }
       
        static public void Task_Answer_gen (int Line) //Принимает индекс массива lines_sequence
        {
            CT_Line = Line;
            current_task_LINE = Convert.ToString(lines[CT_Line]); //Строка текущего задания, например "Сколько студентов (пойдёт идти ходить) на экскурсию?"
            startIndex = current_task_LINE.IndexOf("("); //первая скобка для выборки
            endIndex = current_task_LINE.LastIndexOf(")"); //вторая скобка для выборки
            temp_task = current_task_LINE.Substring(startIndex + 1, endIndex - startIndex - 1);//Варанты ответов из скобок. Первый вариант всегда правильный.
            task_words = temp_task.Split(' ');// Варианты ответов (слова из скобок) превращаем в массив строк
            Answer = (current_task_LINE.Replace((current_task_LINE.Substring(startIndex, (endIndex - startIndex) + 1)), task_words[0])); //Формируем строку являющуюся правильным ответом, чтобы распределить её слова по кнопкам
            Answer_to_buttons = Answer.Split(' ');
            wordCount = Answer_to_buttons.Length; //количество слов в стоке с заданием
            Random random = new Random();
            Array.Sort(Answer_to_buttons, (x, y) => random.Next() - random.Next());// Перемешиваем слова для кнопок      
        }

        static void FisherYatesShuffle<T>(T[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int j = random.Next(i);
                T temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
       
    }
        
}
