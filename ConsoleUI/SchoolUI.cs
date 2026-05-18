using SchoolManagementSystem.Application;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
                string? input = Console.ReadLine();

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
            string name = Console.ReadLine() ?? "";

            Console.Write("Age: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int age))
            {
                Console.WriteLine("Invalid age");
                return;
            }

            var classes = schoolService.GetAllClasses();

            foreach (var c in classes)
                Console.WriteLine($"{c.Id} - {c.Name}");

            Console.Write("Class ID: ");
            string? inputClassId = Console.ReadLine();
            if (!int.TryParse(inputClassId, out int classId))
            {
                Console.WriteLine("Invalid class ID");
                return;
            }

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
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            Console.Write("New name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("New age: ");
            string? inputAge = Console.ReadLine();
            if (!int.TryParse(inputAge, out int age))
            {
                Console.WriteLine("Invalid age");
                return;
            }

            var classes = schoolService.GetAllClasses();
            foreach (var c in classes)
                Console.WriteLine($"{c.Id} - {c.Name}");

            Console.Write("New class ID: ");
            string? inputClassId = Console.ReadLine();
            if (!int.TryParse(inputClassId, out int classId))
            {
                Console.WriteLine("Invalid class ID");
                return;
            }

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
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            var subjects = new List<SubjectType>();

            Console.WriteLine("Enter subjects (empty to stop):");
            while (true)
            {
                string input = Console.ReadLine() ?? "";
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
            Console.WriteLine("Choose subject type:");
            foreach (var type in Enum.GetValues(typeof(SubjectType)))
                Console.WriteLine($"{(int)type} - {type}");

            Console.Write("Type number: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int typeNumber))
            {
                Console.WriteLine("Invalid type number");
                return;
            }

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
            Console.Write("Student Id: ");
            string? inputStudentId = Console.ReadLine();
            if (!int.TryParse(inputStudentId, out int studentId))
            {
                Console.WriteLine("Invalid student ID");
                return;
            }

            Console.Write("Grade value: ");
            string? inputGradeValue = Console.ReadLine();
            if (!int.TryParse(inputGradeValue, out int value))
            {
                Console.WriteLine("Invalid grade value");
                return;
            }

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
            string? inputStudentId = Console.ReadLine();
            if (!int.TryParse(inputStudentId, out int studentId))
            {
                Console.WriteLine("Invalid student ID");
                return;
            }

            Console.Write("Grade Id: ");
            string? inputGradeId = Console.ReadLine();
            if (!int.TryParse(inputGradeId, out int gradeId))
            {
                Console.WriteLine("Invalid grade ID");
                return;
            }

            Console.Write("New value: ");
            string? inputValue = Console.ReadLine();
            if (!int.TryParse(inputValue, out int value))
            {
                Console.WriteLine("Invalid value");
                return;
            }

            Console.Write("Subject type: ");
            Enum.TryParse(Console.ReadLine(), out SubjectType type);

            try
            {
                var student = schoolService.GetStudentById(studentId);
                var subject = new Subject(0, type);
                var grade = new Grade(gradeId, value, student, subject);
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
            Console.Write("Student ID: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

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
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

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
            Console.Write("Class name: ");
            string name = Console.ReadLine() ?? "";

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
            string? inputStudentId = Console.ReadLine();
            if (!int.TryParse(inputStudentId, out int studentId))
            {
                Console.WriteLine("Invalid student ID");
                return;
            }

            Console.Write("Class Id: ");
            string? inputClassId = Console.ReadLine();
            if (!int.TryParse(inputClassId, out int classId))
            {
                Console.WriteLine("Invalid class ID");
                return;
            }

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
            Console.Write("Student ID: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

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
            string? inputStudentId = Console.ReadLine();
            if (!int.TryParse(inputStudentId, out int id))
            {
                Console.WriteLine("Invalid student ID");
                return;
            }

            Console.Write("Date (yyyy-mm-dd): ");
            string? input = Console.ReadLine();
            if (!DateTime.TryParse(input, out DateTime date))
            {
                Console.WriteLine("Invalid date");
                return;
            }

            Console.WriteLine("Attendance type:");
            foreach (var t in Enum.GetValues(typeof(AttendanceType)))
                Console.WriteLine($"{(int)t} - {t}");

            Console.Write("Type number: ");
            string? inputTypeNumber = Console.ReadLine();
            if (!int.TryParse(inputTypeNumber, out int typeNumber))
            {
                Console.WriteLine("Invalid type number");
                return;
            }

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
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int classId))
            {
                Console.WriteLine("Invalid class ID");
                return;
            }

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
            string? inputTeacherId = Console.ReadLine();
            if (!int.TryParse(inputTeacherId, out int teacherId))
            {
                Console.WriteLine("Invalid teacher ID");
                return;
            }

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
            string? inputDayNumber = Console.ReadLine();
            if (!int.TryParse(inputDayNumber, out int dayNumber))
            {
                Console.WriteLine("Invalid day number");
                return;
            }
            var day = (SchoolDay)dayNumber;

            Console.Write("Period: ");
            string? inputPeriod = Console.ReadLine();
            if (!int.TryParse(inputPeriod, out int period))
            {
                Console.WriteLine("Invalid period");
                return;
            }

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
            Console.Write("Schedule Id: ");
            string? inputScheduleId = Console.ReadLine();
            if (!int.TryParse(inputScheduleId, out int scheduleId))
            {
                Console.WriteLine("Invalid schedule ID");
                return;
            }

            Console.Write("Year: ");
            string? inputYear = Console.ReadLine();
            if (!int.TryParse(inputYear, out int year))
            {
                Console.WriteLine("Invalid year");
                return;
            }

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
            Console.Write("Minimum average: ");
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double minAvg))
            {
                Console.WriteLine("Invalid number");
                return;
            }

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
            Console.Write("Maximum average: ");
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double max))
            {
                Console.WriteLine("Invalid number");
                return;
            }

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
            Console.WriteLine("x) Exit");
        }
    }
}
