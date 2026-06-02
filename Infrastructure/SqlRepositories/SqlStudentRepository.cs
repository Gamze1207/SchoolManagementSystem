using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.SqlRepositories
{
    public class SqlStudentRepository : IStudentRepository  
    {

        private readonly SchoolDbContext _db;

        public SqlStudentRepository(SchoolDbContext db)
        {
            _db = db;
        }


        public IReadOnlyList<Student> GetAll()
        {
            return _db.Students
                .Include(s => s.Class)
                .Include(s => s.grades)
                .Include(s => s.attendances)
                .ToList();
        }

        public Student GetById(int id)
        {
            return _db.Students
                .Include(s => s.Class)
                .Include(s => s.grades)
                .Include(s => s.attendances)
                .FirstOrDefault(s => EF.Property<int>(s, "Id") == id);
        }

        public void Save(Student student)
        {
            var entry = _db.Entry(student);
            int currentId = entry.State != EntityState.Detached ? entry.Property<int>("Id").CurrentValue : 0;

            Student? existing = null;
            if (currentId != 0)
            {
                existing = _db.Students.FirstOrDefault(s => EF.Property<int>(s, "Id") == currentId);
            }

            if (existing == null)
            {
                _db.Students.Add(student);
            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(student);
                _db.Entry(existing).Reference(s => s.Class).CurrentValue = student.Class;
            }

            _db.SaveChanges();
        }
    }




}

