using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileStudentRepository : IStudentRepository
    {

        private readonly FileStorage storage;

        public FileStudentRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Student> GetAll()
        {
            var db = storage.Load();         
            return db.Students.AsReadOnly();  
        }

        public Student GetById(int id)
        {
            var db = storage.Load();

            foreach (var student in db.Students)
            {
                if (student.Id == id)
                    return student;
            }

            throw new KeyNotFoundException($"Student not found: {id}");
        }

        public void Save(Student student)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student));

            var db = storage.Load();

           
            if (student.Id == 0)
            {
                var newStudent = new Student(
                    db.NextId++,
                    student.Name,
                    student.Age,
                    student.Class
                );

         
                foreach (var g in student.grades)
                    newStudent.AddGrade(g);

                foreach (var a in student.attendances)
                    newStudent.AddAttendance(a);

                db.Students.Add(newStudent);
            }

            else
            {
                bool found = false;

                for (int i = 0; i < db.Students.Count; i++)
                {
                    if (db.Students[i].Id == student.Id)
                    {
                        var updated = new Student(
                            student.Id,
                            student.Name,
                            student.Age,
                            student.Class
                        );

                        foreach (var g in student.grades)
                            updated.AddGrade(g);

                        foreach (var a in student.attendances)
                            updated.AddAttendance(a);

                        db.Students[i] = updated;
                        found = true;
                        break;
                    }

                }

                if (!found)
                    throw new KeyNotFoundException($"Student not found: {student.Id}");
            }

            storage.Save(db);
        }


    }
}

