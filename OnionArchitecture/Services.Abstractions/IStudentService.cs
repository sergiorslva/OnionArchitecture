using Contracts;

namespace Services.Abstractions
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<StudentDto> GetByIdAsync(Guid studentId, CancellationToken cancellationToken);
        Task<StudentDto> CreateAsync(StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default);
        Task<StudentDto> UpdateAsync(Guid studentId, StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid studentId, CancellationToken cancellationToken = default);
    }
}
