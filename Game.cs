using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Base_C_Lesson_5
{
    public class Game
    {

        List<string> questions = new List<string>();
        List<string> answers = new List<string>();

        public Game()
        {
            // Запрос вопросов и ответов
            getData();
        }

        private void getData()
        {
            string fPath = @"./game.txt";
            if (File.Exists(fPath))
            {
                using (StreamReader sr = new StreamReader(fPath, System.Text.Encoding.UTF8))
                {
                    // Читаем по-строчно из файла
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Разбиваем на вопрос и ответ
                        string[] tmp = line.Split('|');
                        questions.Add(tmp[0].Trim());
                        answers.Add(tmp[1].Trim().ToLower());
                    }
                }
            }
        }

        public List<int> getRandomNums(int cnt=5)
        {
            List<int> nums = new List<int>();
            var rnd = new Random();
            // Генерируем случайные 5 цифр
            while (nums.Count<5)
            {
                int n = rnd.Next(0, 9);
                if (!nums.Contains(n)) nums.Add(n);
            }
            return nums;
        }

        public string getQuestion(int n)
        {
            return questions[n];
        }

        public string getAnswer(int n)
        {
            return answers[n];
        }

        public int showQuestion(int n)
        {
            int score = 0;
            Console.WriteLine(questions[n]+" [Да / Нет]");
            while(true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if(answer == "да" || answer == "нет")
                {
                    score = (answer == answers[n]) ? 1 : -1;
                    break;
                } else
                {
                    Console.WriteLine("Необходимо отвечать только Да или Нет.");
                }
            }
            return score;
        }




    }
}