using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface ITeacherScheduleRepository
    {

        IReadOnlyList<TeacherSchedule> GetAll();
        TeacherSchedule GetById(int id);

        void Save(TeacherSchedule schedule);

    }
}
