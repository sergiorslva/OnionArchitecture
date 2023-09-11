using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class TeacherRepository : ITeacherRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public TeacherRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Teachers.ToListAsync(cancellationToken);
        }

        public async Task<Teacher> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Teachers.FirstAsync(cancellationToken);
        }

        public void Insert(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
        }

        public void Remove(Teacher teacher)
        {
            _dbContext.Teachers.Update(teacher);
        }

        public void Update(Teacher teacher)
        {
            _dbContext.Teachers.Update(teacher);
        }
    }
}
