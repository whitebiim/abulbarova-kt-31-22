//Фильтрация по кафедре (ID или названию)

namespace abulbarovakt_31_22.Filters
{
    public class TeacherDepartmentFilter
    {
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}