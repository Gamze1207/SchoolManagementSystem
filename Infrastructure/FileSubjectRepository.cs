using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileSubjectRepository : ISubjectRepository
    {
        private readonly FileStorage storage;

        public FileSubjectRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Subject> GetAll()
        {
            var db = storage.Load();
            return db.Subjects.AsReadOnly();
        }

        public Subject GetById(int id)
        {
            var db = storage.Load();

            foreach (var subject in db.Subjects)
            {
                if (subject.Id == id)
                    return subject;
            }

            throw new KeyNotFoundException($"Subject not found: {id}");
        }

        public void Save(Subject subject)
        {
            if (subject is null)
                throw new ArgumentNullException(nameof(subject));

            var db = storage.Load();

            if (subject.Id == 0)
            {
                var newSubject = new Subject(
                    db.NextId++,
                    subject.Type
                );

                if (subject.Teachers != null)
                {
                    foreach (var t in subject.Teachers)
                        newSubject.AddTeacher(t);
                }

                db.Subjects.Add(newSubject);
            }
            else
            {
                bool found = false;

                for (int i = 0; i < db.Subjects.Count; i++)
                {
                    if (db.Subjects[i].Id == subject.Id)
                    {
                        var updated = new Subject(
                            subject.Id,
                            subject.Type
                        );

                        if (subject.Teachers != null)
                        {
                            foreach (var t in subject.Teachers)
                                updated.AddTeacher(t);
                        }

                        db.Subjects[i] = updated;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"Subject not found: {subject.Id}");
            }

            storage.Save(db);
        }

    }
}
