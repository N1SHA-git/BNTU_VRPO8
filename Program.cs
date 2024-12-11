using System;
using System.Collections.Generic;

class Program
{
    // Класс для хранения информации о студенте
    public class Student
    {
        public string Name { get; set; }
        public Dictionary<string, double> Subjects { get; set; }

        public Student(string name)
        {
            Name = name;
            Subjects = new Dictionary<string, double>();
        }

        // Метод для добавления оценки по предмету
        public void AddGrade(string subject, double grade)
        {
            if (Subjects.ContainsKey(subject))
            {
                Subjects[subject] = grade;
            }
            else
            {
                Subjects.Add(subject, grade);
            }
        }

        // Метод для отображения информации о студенте
        public void DisplayInfo()
        {
            Console.WriteLine($"Студент: {Name}");
            foreach (var subject in Subjects)
            {
                Console.WriteLine($"{subject.Key}: {subject.Value}");
            }
        }
    }

    // Основной метод программы
    static void Main()
    {
        List<Student> students = new List<Student>();  // Список студентов
        bool continueInput = true;

        while (continueInput)
        {
            // Ввод имени студента
            Console.WriteLine("Введите имя студента:");
            string studentName = Console.ReadLine();

            // Создаем нового студента
            Student student = new Student(studentName);

            // Ввод информации о предметах и оценках
            bool continueSubjects = true;
            while (continueSubjects)
            {
                Console.WriteLine("Введите название предмета:");
                string subjectName = Console.ReadLine();

                Console.WriteLine("Введите оценку по предмету (0 - 5):");
                double grade = 0;
                while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 5)
                {
                    Console.WriteLine("Некорректная оценка! Введите число от 0 до 5.");
                }

                student.AddGrade(subjectName, grade);

                Console.WriteLine("Хотите ввести еще один предмет для этого студента? (y/n)");
                string continueChoice = Console.ReadLine().ToLower();
                if (continueChoice != "y")
                {
                    continueSubjects = false;
                }
            }

            // Добавляем студента в список
            students.Add(student);

            // Запрос, хотите ли продолжить вводить студентов
            Console.WriteLine("Хотите ввести информацию о другом студенте? (y/n)");
            string continueChoiceStudent = Console.ReadLine().ToLower();
            if (continueChoiceStudent != "y")
            {
                continueInput = false;
            }
        }

        // Вывод всех студентов и их оценок
        Console.WriteLine("\nВсе студенты и их оценки:");
        foreach (var student in students)
        {
            student.DisplayInfo();
            Console.WriteLine();
        }
    }
}
