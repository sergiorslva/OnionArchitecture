using Contracts;

namespace Services.Abstractions
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TeacherDto> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken);
        Task<TeacherDto> CreateAsync(TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default);
        Task<TeacherDto> UpdateAsync(Guid teacherId, TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid teacherId, CancellationToken cancellationToken = default);
    }
}
