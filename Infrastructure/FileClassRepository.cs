using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileClassRepository : IClassRepository
    {

        private readonly FileStorage storage;

        public FileClassRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Class> GetAll()
        {
            var db = storage.Load();
            return db.Classes.AsReadOnly();
        }

        public Class GetById(int id)
        {
            var db = storage.Load();

            foreach (var c in db.Classes)
            {
                if (c.Id == id)
                    return c;
            }

            throw new KeyNotFoundException($"Class not found: {id}");
        }

        public void Save(Class _class)
        {
            if (_class is null)
                throw new ArgumentNullException(nameof(_class));

            var db = storage.Load();

            // CREATE
            if (_class.Id == 0)
            {
                var newClass = new Class(
                    db.NextId++,
                    _class.Name
                );

                // copy students
                if (_class.students != null)
                {
                    foreach (var s in _class.students)
                        newClass.AddStudent(s);
                }


                if (_class.schedules != null)
                {
                    foreach (var sch in _class.schedules)
                        newClass.AddSchedule(sch);
                }

                db.Classes.Add(newClass);
            }
            else
            {

                bool found = false;

                for (int i = 0; i < db.Classes.Count; i++)
                {
                    if (db.Classes[i].Id == _class.Id)
                    {
                        var updated = new Class(
                            _class.Id,
                            _class.Name
                        );

                        if (_class.students != null)
                        {
                            foreach (var s in _class.students)
                                updated.AddStudent(s);
                        }

                        if (_class.schedules != null)
                        {
                            foreach (var sch in _class.schedules)
                                updated.AddSchedule(sch);
                        }

                        db.Classes[i] = updated;
                        found = true;
                        break;

                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"Class not found: {_class.Id}");

            }
            storage.Save(db);
        }
    }
}
