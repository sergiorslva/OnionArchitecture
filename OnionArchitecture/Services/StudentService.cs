using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    public sealed class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentDto> CreateAsync(StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default)
        {
            var student = studentForCreationDto.Adapt<Student>();            
            _studentRepository.Insert(student);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return student.Adapt<StudentDto>();
        }

        public async Task DeleteAsync(Guid studentId, CancellationToken cancellationToken = default)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student is null)
            {
                throw new Exception();
            }

            student.Deleted = true;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var students = await _studentRepository.GetAllAsync(cancellationToken);

            return students.Adapt<IEnumerable<StudentDto>>();
        }

        public async Task<StudentDto> GetByIdAsync(Guid studentId, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student is null)
            {
                throw new Exception();
            }

            return student.Adapt<StudentDto>();
        }

        public async Task<StudentDto> UpdateAsync(Guid studentId, StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student is null)
            {
                throw new Exception();
            }

            student.Phone = studentForCreationDto.Phone;
            student.Email = studentForCreationDto.Email;
            student.StudentLevel = studentForCreationDto.StudentLevel;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return student.Adapt<StudentDto>();
        }
    }
}
