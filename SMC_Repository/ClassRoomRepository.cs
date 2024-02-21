using Microsoft.EntityFrameworkCore;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Dtos.Result;
using SMC_Entities.Models;
using SMC_Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SMC_Repository
{
    public class ClassRoomRepository : BaseRepo<ClassRoom>, IClassRoomRepository
    {
        protected SmcContext _smcContext { get; set; }

        public ClassRoomRepository(SmcContext smcContext) : base(smcContext)
        {
            _smcContext = smcContext;
        }

        public override IQueryable<ClassRoom> GetAll()
        {
            return _smcContext.ClassRoom.Include(s => s.Section);
        }

        public IEnumerable<StudentRedByClassRoomNumberVm> GetAllStudentByClassRoomId(int ClassRoomId)
        {
            var data = _smcContext.Student.Where(r => r.ClassRoomId == ClassRoomId)
                .Include(r => r.ClassRoom)
                .Join(_smcContext.Result, s => s.Id, re => re.StudentId, (s, re) =>
                   new
                   {
                       StudentId = s.Id,
                       FullName = s.FirstName + " " + s.MiddleName + " " + s.LastName,
                       s.ChristeningName,
                       re.Marks,
                       TotalCourses = s.ClassRoom.TotalCourses
                   })
                .GroupBy(x =>
                    new
                    {
                        x.FullName,
                        x.StudentId,
                        x.ChristeningName,
                        x.TotalCourses
                    })
                .Select(g =>
                    new StudentRedByClassRoomNumberVm
                    {
                        StudentId = g.Key.StudentId,
                        ChristeningName = g.Key.ChristeningName,
                        FullName = g.Key.FullName,
                        TotalScore = g.Sum(y => y.Marks),
                        TotalCourses = g.Key.TotalCourses
                    })
                .ToList();

            foreach (var item in data)
            {
                item.resultGroupByStudentIdVms = _smcContext.Result.Where(r => r.StudentId == item.StudentId).Include(c => c.Course)
                   .GroupBy(l => new { CourseName = l.Course.Name })
                   .Select(g => new ResultGroupByStudentIdVm
                   {
                       TotalScore = g.Average(y => y.Marks),
                       CourseName = g.Key.CourseName
                   });
                item.TotalScore = item.resultGroupByStudentIdVms.Sum(t => t.TotalScore);
            }
            return data;
        }
    }
}
