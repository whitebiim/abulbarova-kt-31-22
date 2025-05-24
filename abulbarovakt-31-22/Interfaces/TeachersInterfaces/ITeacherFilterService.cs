﻿using abulbarovakt_31_22.Database;
using abulbarovakt_31_22.Filters;
using abulbarovakt_31_22.Models;
using Microsoft.EntityFrameworkCore;


//Преподаватели фильтрацию по кафедре, по должности

namespace abulbarovakt_31_22.Interfaces.TeachersInterfaces
{
    public interface ITeacherFilterInterfaceService
    {
        // Получение по ID
        public Teacher GetTeacherById(int teacherId);
        // По ФИО
        public Task<Teacher[]> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken);
        // По кафедре
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
        // По должности
        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken);
    }
    
    
    // Реализация ITeacherFilterService
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