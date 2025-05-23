

﻿using abulbarovakt_31_22.Database;
using abulbarovakt_31_22.Filters;
using abulbarovakt_31_22.Models;
using abulbarovakt_31_22.Database;
using Microsoft.EntityFrameworkCore;

namespace abulbarovakt_31_22.Interfaces.TeachersInterfaces
{
    public interface ITeacherFilterInterfaceService
    {
        public Teacher GetTeacherById(int teacherId);
        public Task<Teacher[]> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken);
    }

    public class ITeacherFilterService : ITeacherFilterInterfaceService
    {
        private readonly TeacherDbContext _dbContext;
        public ITeacherFilterService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return _dbContext.Teachers.Where(t => t.TeachersId == teacherId).FirstOrDefault();
        }

        public Task<Teacher[]> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken = default)
        {
            var teacher = _dbContext.Set<Teacher>().Where(w => w.FirstName == filter.FirstName && w.LastName == filter.LastName && w.MiddleName == filter.MiddleName).ToArrayAsync(cancellationToken);

            return teacher;
        }

        public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teacher = await _dbContext.Set<Teacher>().Where(w => w.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

            return teacher;
        }

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teacher = _dbContext.Set<Teacher>().Where(w => w.Position.PositionName == filter.PositionName).ToArrayAsync(cancellationToken);

            return teacher;
        }
    }
}