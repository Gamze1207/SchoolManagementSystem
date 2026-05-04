using SchoolManagementSystem.Application;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ConsoleUI
{
    public class SchoolUI
    {
        private readonly SchoolService schoolService;
        public SchoolUI(SchoolService schoolService)
        {
            this.schoolService = schoolService;
        }
        public void Run()
        {
            bool running = true;

            while (running)
            {
                Menu();

                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        UpdateStudent();
                        break;
                    case "3":
                        AddTeacher();
                        break;
                    case "4":
                        AddSubject();
                        break;
                    case "5":
                        AddGrade();
                        break;
                    case "6":
                        UpdateGrade();
                        break;
                    case "7":
                        CalculateAverageGrade();
                        break;
                    case "8":
                        GenerateReportCard();
                        break;
                    case "9":
                        AddClass();
                        break;
                    case "10":
                        AddStudentToClass();
                        break;
                    case "11":
                        GetAbsences();
                        break;
                    case "12":
                        AddAttendance();
                        break;
                    case "13":
                        GetGradesBySubject();
                        break;
                    case "14":
                        GetGradesByClass();
                        break;
                    case "15":
                        GetTeacherInfo();
                        break;
                    case "16":
                        GetSchedule();
                        break;
                    case "17":
                        CheckForFreeTeachers();
                        break;
                    case "18":
                        SetScheduleYear();
                        break;
                    case "19":
                        GetTopStudents();
                        break;
                    case "20":
                        GetProblemStudents();
                        break;
                    case "x":
                        running = false;
                        break;
                }
            }
        }

        private void AddStudent()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void UpdateStudent()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void AddTeacher()
        {
            //Dzheyda
            Console.Write("Name: ");
            string name = Console.ReadLine();

            var subjects = new List<SubjectType>();

            Console.WriteLine("Enter subjects (empty to stop):");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;

                if (Enum.TryParse(input, out SubjectType subject))
                    subjects.Add(subject);
            }

            try
            {
                schoolService.AddTeacher(name, subjects);
                Console.WriteLine("Teacher added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void AddSubject()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void AddGrade()
        {
            //Dzheyda
            Console.Write("Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Grade value: ");
            int value = int.Parse(Console.ReadLine());

            Console.Write("Subject type: ");
            Enum.TryParse(Console.ReadLine(), out SubjectType type);

            try
            {
                schoolService.AddGrade(studentId, value, new Subject(0, type));
                Console.WriteLine("Grade added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void UpdateGrade()
        {
            //Dzheyda
            Console.Write("Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Grade Id: ");
            int gradeId = int.Parse(Console.ReadLine());

            Console.Write("New value: ");
            int value = int.Parse(Console.ReadLine());

            Console.Write("Subject type: ");
            Enum.TryParse(Console.ReadLine(), out SubjectType type);

            try
            {
                var grade = new Grade(gradeId, value, null, new Subject(0, type));
                schoolService.UpdateGrade(studentId, grade);

                Console.WriteLine("Grade updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void CalculateAverageGrade()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void GenerateReportCard()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void AddClass()
        {
            //Dzheyda
            Console.Write("Class name: ");
            string name = Console.ReadLine();

            try
            {
                schoolService.AddClass(name);
                Console.WriteLine("Class added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void AddStudentToClass()
        {
            //Dzheyda
            Console.Write("Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Class Id: ");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                schoolService.AddStudentToClass(studentId, classId);
                Console.WriteLine("Student added to class!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void GetAbsences()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void AddAttendance()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void GetGradesBySubject()
        {
            //Dzheyda
            Console.Write("Subject type: ");
            Enum.TryParse(Console.ReadLine(), out SubjectType subject);

            try
            {
                var grades = schoolService.GetGradesBySubject(subject);

                foreach (var g in grades)
                    Console.WriteLine($"Student: {g.Student.Name} | Grade: {g.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void GetGradesByClass()
        {
            //Dzheyda
            Console.Write("Class Id: ");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                var result = schoolService.GetClassAverage(classId);

                foreach (var item in result)
                    Console.WriteLine($"{item.Student.Name} | Avg: {item.Average:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void GetTeacherInfo()
        {
            //Dzheyda
            Console.Write("Teacher Id: ");
            int teacherId = int.Parse(Console.ReadLine());

            try
            {
                var info = schoolService.GetTeacherInfo(teacherId);

                Console.WriteLine($"Name: {info.Teacher.Name}");

                Console.WriteLine("Subjects:");
                foreach (var s in info.Subjects)
                    Console.WriteLine($"- {s}");

                Console.WriteLine("Schedules:");
                foreach (var sch in info.Schedules)
                    Console.WriteLine($"{sch.Subject} | Class: {sch.Class?.Name} | Hours: {sch.Hours}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void GetSchedule()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void CheckForFreeTeachers()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void SetScheduleYear()
        {
            //Dzheyda
            Console.Write("Schedule Id: ");
            int scheduleId = int.Parse(Console.ReadLine());

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            try
            {
                schoolService.SetScheduleYear(scheduleId, year);
                Console.WriteLine("Schedule year updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void GetTopStudents()
        {
            //Gamze
            throw new NotImplementedException();
        }

        private void GetProblemStudents()
        {
            //Dzheyda
            Console.Write("Maximum average: ");
            double max = double.Parse(Console.ReadLine());

            try
            {
                var students = schoolService.GetProblemStudents(max);

                foreach (var s in students)
                    Console.WriteLine($"{s.Name} - {s.grades.Average(g => g.Value):F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("==== School Management System ====");
            Console.WriteLine("1) Add a student.");
            Console.WriteLine("2) Update a student.");
            Console.WriteLine("3) Add a teacher.");
            Console.WriteLine("4) Add a subject.");
            Console.WriteLine("5) Add a grade.");
            Console.WriteLine("6) Update a grade.");
            Console.WriteLine("7) Calculate average grade.");
            Console.WriteLine("8) Generate a report card.");
            Console.WriteLine("9) Add a class.");
            Console.WriteLine("10) Add a student to a class.");
            Console.WriteLine("11) Get absences.");
            Console.WriteLine("12) Add an absence.");
            Console.WriteLine("13) Get grades by subject.");
            Console.WriteLine("14) Get grades by class.");
            Console.WriteLine("15) Get teacher info.");
            Console.WriteLine("16) Get schedule.");
            Console.WriteLine("17) Check for free teachers.");
            Console.WriteLine("18) Set schedule year.");
            Console.WriteLine("19) Get top students.");
            Console.WriteLine("20) Get problem students.");
            Console.WriteLine("x. Exit");
        }
    }
}
