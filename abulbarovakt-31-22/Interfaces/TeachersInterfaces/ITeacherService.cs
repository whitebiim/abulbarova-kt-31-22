

﻿using abulbarovakt_31_22.Database;
using abulbarovakt_31_22.Models;


//Преподаватели
namespace abulbarovakt_31_22.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        // Добавление преподавателя
        public Task<Teacher> AddTeacher(Teacher teacher);
        // Проверка существования
        public bool TeacherExists(int teacherId);
        // Обновление данных
        public bool UpdateTeacher(Teacher teacher);
        // Удаление преподавателя
        public bool DeleteTeacher(Teacher teacher);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            _dbContext.Add(teacher);
            await _dbContext.SaveChangesAsync();
            return teacher;
        }

        public bool TeacherExists(int teacherId)
        {
            return _dbContext.Teachers.Any(t => t.TeachersId == teacherId);
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _dbContext.Update(teacher);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _dbContext.Remove(teacher);
            return _dbContext.SaveChanges() > 0;
        }

    }
}