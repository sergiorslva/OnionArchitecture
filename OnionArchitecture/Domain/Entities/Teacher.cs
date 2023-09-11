namespace Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset DateCreated { get; } = DateTimeOffset.Now;       
        public Boolean Deleted { get; set; } = false;
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
    }
}
