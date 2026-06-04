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
                .FirstOrDefault(s => s.Id == id);
        }

        public void Save(Student student)
        {
            if (student.Id == 0)
            {
                _db.Students.Add(student);
            }
            else
            {
                _db.Students.Update(student);
            }

            _db.SaveChanges();
        }
    }
}

