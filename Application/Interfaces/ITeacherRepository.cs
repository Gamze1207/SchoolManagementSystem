using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface ITeacherRepository
    {

        IReadOnlyList<Teacher> GetAll();
        Teacher GetById(int id);
        void Save(Teacher teacher);

    }
}
