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
    public class SqlTeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _db;

        public SqlTeacherRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Teacher> GetAll()
        {
            return _db.Teachers
                .Include(t => t.schedules)
                .ToList();
        }

        public Teacher? GetById(int id)
        {
            return _db.Teachers
                .Include(t => t.schedules)
                .FirstOrDefault(t => t.Id == id);
        }

        public void Save(Teacher teacher)
        {
            var existing = _db.Teachers
                .Include(t => t.schedules)
                .FirstOrDefault(t => t.Id == teacher.Id);

            if (existing == null)
            {
                _db.Teachers.Add(teacher);
            }
            else
            {
                _db.Entry(existing)
                    .CurrentValues
                    .SetValues(teacher);
            }

            _db.SaveChanges();
        }
    }
}
