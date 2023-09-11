using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class StudentRepository : IStudentRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public StudentRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Students.ToListAsync(cancellationToken);
        }

        public async Task<Student> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Students.FirstAsync(cancellationToken);
        }

        public void Insert(Student student)
        {
            _dbContext.Students.Add(student);
        }

        public void Remove(Student student)
        {
            _dbContext.Students.Update(student);
        }

        public void Update(Student student)
        {
            _dbContext.Students.Update(student);
        }
    }
}
