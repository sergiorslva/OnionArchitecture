using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Teacher> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken = default);
        void Insert(Teacher teacher);
        void Update(Teacher teacher);
        void Remove(Teacher teacher);
    }
}
