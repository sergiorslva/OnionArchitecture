using Domain.Enums;

namespace Contracts
{
    public class StudentForCreationDto
    {        
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public StudentLevelEnum StudentLevel { get; set; }
    }
}
