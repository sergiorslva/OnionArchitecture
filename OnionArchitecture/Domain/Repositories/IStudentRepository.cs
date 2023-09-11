using Domain.Entities;

namespace Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Student> GetByIdAsync(Guid studentId, CancellationToken cancellationToken = default);
        void Insert(Student student);
        void Remove(Student student);
    }
}
