
//Кафедра
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace abulbarovakt_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? TeacherHeaderId { get; set; }
        [JsonIgnore]
        public Teacher? Teacher { get; set; }

        public bool isValidDepartmentName()
        {
            // проверка валидности названия кафедры (регулярное выражение)
            return Regex.Match(DepartmentName, @"^[А-ЯЁ][а-яё](\S+)?\s[А-ЯЁ][а-яё]+$").Success;
        }
    }
}