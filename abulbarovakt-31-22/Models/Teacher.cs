

namespace abulbarovakt_31_22.Models
{
    public class Teacher
    {
        public int TeachersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}