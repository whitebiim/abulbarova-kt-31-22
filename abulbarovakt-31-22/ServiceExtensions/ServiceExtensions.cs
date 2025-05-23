

﻿using abulbarovakt_31_22.Interfaces.DepartmentInterfaces;
using abulbarovakt_31_22.Interfaces.PositionInterfaces;
using abulbarovakt_31_22.Interfaces.TeachersInterfaces;

namespace abulbarovakt_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherFilterInterfaceService, ITeacherFilterService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPositionService, PositionService>();

            return services;
        }
    }
}