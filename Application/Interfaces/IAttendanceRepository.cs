using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IAttendanceRepository
    {

        IReadOnlyList<Attendance> GetAll();
        Attendance GetById(int id);

        void Save(Attendance attendance);

    }
}
