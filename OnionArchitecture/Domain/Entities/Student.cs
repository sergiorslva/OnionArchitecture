using Domain.Enums;

namespace Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Boolean Deleted { get; set; } = false;
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public StudentLevelEnum StudentLevel { get; set; }
    }
}
