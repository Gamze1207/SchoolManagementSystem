using SchoolManagementSystem.Application;
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
            throw new NotImplementedException();
        }

        private void AddSubject()
        {
            //Gamze
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private void GetTopStudents()
        {
            //Gamze
            throw new NotImplementedException();
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
