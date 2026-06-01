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
                .FirstOrDefault();//g => g.Id == id
        }

        public void Save(Grade grade)
        {
            var existingGrade = _db.Grades
                .FirstOrDefault();//g => g.Id == id

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

