using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    public sealed class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TeacherDto> CreateAsync(TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default)
        {
            var teacher = teacherForCreationDto.Adapt<Teacher>();
            _teacherRepository.Insert(teacher);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return teacher.Adapt<TeacherDto>();
        }

        public async Task<TeacherDto> UpdateAsync(Guid teacherId, TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);
            if (teacher is null)
            {
                throw new Exception();
            }

            teacher.Phone = teacherForCreationDto.Phone;
            teacher.Email = teacherForCreationDto.Email;
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return teacher.Adapt<TeacherDto>();
        }

        public async Task DeleteAsync(Guid teacherId, CancellationToken cancellationToken = default)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);            
            if(teacher is null)
            {
                throw new Exception();
            }

            teacher.Deleted = true;
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherRepository.GetAllAsync(cancellationToken);

            return teachers.Adapt<IEnumerable<TeacherDto>>();
        }

        public async Task<TeacherDto> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);
            if (teacher is null)
            {
                throw new Exception();
            }

            return teacher.Adapt<TeacherDto>();
        }
    }
}