using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileGradeRepository : IGradeRepository
    {

        private readonly FileStorage storage;

        public FileGradeRepository(FileStorage storage)
        {
            this.storage = storage ;
        }

        public IReadOnlyList<Grade> GetAll()
        {
            var db = storage.Load();
            return db.Grades.AsReadOnly();
        }

        public Grade GetById(int id)
        {
            var db = storage.Load();

            foreach (var grade in db.Grades)
            {
                if (grade.Id == id)
                    return grade;
            }

            throw new KeyNotFoundException($"Grade not found: {id}");
        }

        public void Save(Grade _grade)
        {
            if (_grade is null)
                throw new ArgumentNullException(nameof(_grade));

            var db = storage.Load();


            if (_grade.Id == 0)
            {
                var newGrade = new Grade(
                    db.NextId++,
                    _grade.Value,
                    _grade.Student,
                    _grade.Subject
                );

                db.Grades.Add(newGrade);
            }

            else
            {
                bool found = false;

                for (int i = 0; i < db.Grades.Count; i++)
                {
                    if (db.Grades[i].Id == _grade.Id)
                    {
                        var updated = new Grade(
                            _grade.Id,
                            _grade.Value,
                            _grade.Student,
                            _grade.Subject
                        );

                        db.Grades[i] = updated;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"Grade not found: {_grade.Id}");
            }

            storage.Save(db);


        }

     }
}
