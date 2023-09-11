namespace Contracts
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; }
        public Boolean Deleted { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
    } 
}