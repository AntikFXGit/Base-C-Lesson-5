using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Base_C_Lesson_5
{
    public class Students
    {
        public Students()
        {


        }

        public static Dictionary<string, double> GetAverageGrades()
        {
            var students = new Dictionary<string, double>();
            string fPath = @"./students.txt";
            if (File.Exists(fPath))
            {
                using (StreamReader sr = new StreamReader(fPath, System.Text.Encoding.UTF8))
                {
                    // Читаем по-строчно из файла
                    string line;
                    List<string> lines = new List<string>();
                    while ((line = sr.ReadLine()) != null) lines.Add(line);

                    // Разбираем строки
                    int studentsCnt;
                    Int32.TryParse(lines[0], out studentsCnt);

                    // Студенты
                    for (int i = 1; i < lines.Count; i++)
                    {
                        string[] tmp = lines[i].Trim().Split(' ');
                        double aGrade = (double.Parse(tmp[2]) + double.Parse(tmp[3]) + double.Parse(tmp[4])) / 3;
                        aGrade = Math.Round(aGrade, 1);
                        string sTitle = tmp[0].Trim() + " " + tmp[1].Trim();
                        students[sTitle] = aGrade;
                    }

                    // Сортируем студентов
                    students = students.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                }
            }
            return students;
        }

        public static void showTheWorstStudents(Dictionary<string, double> students, int cntBalls = 3)
        {
            double lastAvGrade = 0;
            int cnt = 0;
            foreach (KeyValuePair<string, double> val in students)
            {
                if(lastAvGrade!= val.Value)
                {
                    cnt++;
                    lastAvGrade = val.Value;
                }

                if (cnt > cntBalls) break;
                Console.WriteLine(val.Key + " = " + val.Value);
            }
        }


    }
}