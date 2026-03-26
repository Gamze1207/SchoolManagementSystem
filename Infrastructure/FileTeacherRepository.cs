using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileTeacherRepository : ITeacherRepository
    {

        private readonly FileStorage storage;

        public FileTeacherRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Teacher> GetAll()
        {
            var db = storage.Load();
            return db.Teachers.AsReadOnly();
        }

        public Teacher GetById(int id)
        {
            var db = storage.Load();

            foreach (var teacher in db.Teachers)
            {
                if (teacher.Id == id)
                    return teacher;
            }

            throw new KeyNotFoundException($"Teacher not found: {id}");
        }

        public void Save(Teacher teacher)
        {
            if (teacher is null)
                throw new ArgumentNullException(nameof(teacher));

            var db = storage.Load();

            if (teacher.Id == 0)
            {
                var newTeacher = new Teacher(
                    db.NextId++,
                    teacher.Name
                );

                if (teacher.subjects != null)
                {
                    foreach (var s in teacher.subjects)
                        newTeacher.AddSubject(s);
                }

                if (teacher.schedules != null)
                {
                    foreach (var sch in teacher.schedules)
                        newTeacher.AddSchedule(sch);
                }

                db.Teachers.Add(newTeacher);
            }

            else
            {
                bool found = false;

                for (int i = 0; i < db.Teachers.Count; i++)
                {
                    if (db.Teachers[i].Id == teacher.Id)
                    {
                        var updated = new Teacher(
                            teacher.Id,
                            teacher.Name
                        );

                        if (teacher.subjects != null)
                        {
                            foreach (var s in teacher.subjects)
                                updated.AddSubject(s);
                        }

                        if (teacher.schedules != null)
                        {
                            foreach (var sch in teacher.schedules)
                                updated.AddSchedule(sch);
                        }

                        db.Teachers[i] = updated;

                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"Teacher not found: {teacher.Id}");
            }

            storage.Save(db);
        }





    }
}
