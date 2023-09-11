using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation
{
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController: ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var teachersDto = await _teacherService.GetAllAsync(cancellationToken);

            return Ok(teachersDto);
        }

        [HttpGet]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> GetById(Guid teacherId, CancellationToken cancellationToken)
        {
            var teacherDto = await _teacherService.GetByIdAsync(teacherId, cancellationToken);

            return Ok(teacherDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken)
        {
            var teacherDto = await _teacherService.CreateAsync(teacherForCreationDto, cancellationToken);

            return Ok(teacherDto);
        }

        [HttpPut]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> UpdateTeacher(Guid teacherId, [FromBody] TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken)
        {
            var teacherDto = await _teacherService.UpdateAsync(teacherId, teacherForCreationDto, cancellationToken);

            return Ok(teacherDto);
        }

        [HttpDelete]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> DeleteTeacher(Guid teacherId, CancellationToken cancellationToken)
        {
            await _teacherService.DeleteAsync(teacherId, cancellationToken);

            return NoContent();
        }
    }
}