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
            Console.Write("Student name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            var classes = schoolService.GetAllClasses();

            foreach (var c in classes)
                Console.WriteLine($"{c.Id} - {c.Name}");

            Console.Write("Class ID: ");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                var schoolClass = classes.First(c => c.Id == classId);
                schoolService.AddStudent(name, age, schoolClass);
                Console.WriteLine("Student added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void UpdateStudent()
        {
            //Gamze
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("New name: ");
            string name = Console.ReadLine();

            Console.Write("New age: ");
            int age = int.Parse(Console.ReadLine());

            var classes = schoolService.GetAllClasses();
            foreach (var c in classes)
                Console.WriteLine($"{c.Id} - {c.Name}");

            Console.Write("New class ID: ");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                var schoolClass = classes.First(c => c.Id == classId);
                schoolService.UpdateStudent(id, name, age, schoolClass);
                Console.WriteLine("Student updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void AddTeacher()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void AddSubject()
        {
            //Gamze
            Console.WriteLine("Choose subject type:");
            foreach (var type in Enum.GetValues(typeof(SubjectType)))
                Console.WriteLine($"{(int)type} - {type}");

            Console.Write("Type number: ");
            int typeNumber = int.Parse(Console.ReadLine());

            try
            {
                var subjectType = (SubjectType)typeNumber;
                var subject = new Subject(0, subjectType);

                schoolService.AddSubject(subject);
                Console.WriteLine("Subject added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void AddGrade()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void UpdateGrade()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void CalculateAverageGrade()
        {
            //Gamze
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                double avg = schoolService.CalculateAverageGrade(id);
                Console.WriteLine($"Average grade: {avg}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void GenerateReportCard()
        {
            //Gamze
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var report = schoolService.GenerateReportCard(id);

                Console.WriteLine($"Student: {report.Student.Name}");
                Console.WriteLine($"Average: {report.Average}");

                Console.WriteLine("Grades:");
                foreach (var g in report.Grades)
                    Console.WriteLine($"{g.Subject.Type}: {g.Value}");

                Console.WriteLine("Absences:");
                foreach (var a in report.Absences)
                    Console.WriteLine($"{a.Date.ToShortDateString()} - {a.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void AddClass()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void AddStudentToClass()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void GetAbsences()
        {
            //Gamze
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var absences = schoolService.GetAbsences(id);

                foreach (var a in absences)
                    Console.WriteLine($"{a.Date.ToShortDateString()} - {a.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void AddAttendance()
        {
            //Gamze
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Attendance type:");
            foreach (var t in Enum.GetValues(typeof(AttendanceType)))
                Console.WriteLine($"{(int)t} - {t}");

            Console.Write("Type number: ");
            int typeNumber = int.Parse(Console.ReadLine());

            try
            {
                var status = (AttendanceType)typeNumber;
                schoolService.AddAttendance(id, date, status);
                Console.WriteLine("Attendance added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void GetGradesBySubject()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void GetGradesByClass()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void GetTeacherInfo()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void GetSchedule()
        {
            //Gamze
            try
            {
                var schedules = schoolService.GetSchedule();

                foreach (var s in schedules)
                {
                    Console.WriteLine(
                        $"{s.Id} | " +
                        $"{s.Slot.Day} Period {s.Slot.Period} | " +
                        $"Teacher: {s.Schedules.Teacher.Name} | " +
                        $"Class: {s.Schedules.Class.Name} | " +
                        $"Subject: {s.Schedules.Subject}"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void CheckForFreeTeachers()
        {
            //Gamze
            Console.WriteLine("Day:");
            foreach (var d in Enum.GetValues(typeof(SchoolDay)))
                Console.WriteLine($"{(int)d} - {d}");

            Console.Write("Choose day: ");
            int dayNumber = int.Parse(Console.ReadLine());
            var day = (SchoolDay)dayNumber;

            Console.Write("Period: ");
            int period = int.Parse(Console.ReadLine());

            try
            {
                var freeTeachers = schoolService.GetFreeTeachers(day, period);

                foreach (var t in freeTeachers)
                    Console.WriteLine($"{t.Id} - {t.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void SetScheduleYear()
        {
            //Dzheyda
            throw new NotImplementedException();
        }

        private void GetTopStudents()
        {
            //Gamze
            Console.Write("Minimum average: ");
            double minAvg = double.Parse(Console.ReadLine());

            try
            {
                var students = schoolService.GetTopStudents(minAvg);

                foreach (var s in students)
                    Console.WriteLine($"{s.Id} - {s.Name} (Avg: {s.grades.Average(g => g.Value)})");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        private void GetProblemStudents()
        {
            //Dzheyda
            throw new NotImplementedException();
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
