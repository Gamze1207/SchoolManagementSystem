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
    public class SqlGradeRepository:IGradeRepository
    {
        private readonly SchoolDbContext _db;

        public SqlGradeRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Grade> GetAll()
        {
            return _db.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .ToList();
        }

        public Grade? GetById(int id)
        {
            return _db.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefault(g => EF.Property<int>(g, "Id") == id);
        }

        public void Save(Grade grade)
        {
            var entry = _db.Entry(grade);
            int currentId = entry.State != EntityState.Detached ? entry.Property<int>("Id").CurrentValue : 0;

            Grade? existingGrade = null;
            if (currentId != 0)
            {
                existingGrade = _db.Grades.FirstOrDefault(g => EF.Property<int>(g, "Id") == currentId);
            }

            if (existingGrade == null)
            {
                _db.Grades.Add(grade);
            }
            else
            {
                _db.Entry(existingGrade)
                    .CurrentValues
                    .SetValues(grade);
            }

            _db.SaveChanges();
        }
    }
}

