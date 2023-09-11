using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation
{
    [ApiController]
    [Route("api/student")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var studentsDto = await _studentService.GetAllAsync(cancellationToken);

            return Ok(studentsDto);
        }

        [HttpGet]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> GetById(Guid studentId, CancellationToken cancellationToken)
        {
            var studentDto = await _studentService.GetByIdAsync(studentId, cancellationToken);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken)
        {
            var studentDto = await _studentService.CreateAsync(studentForCreationDto, cancellationToken);

            return Ok(studentDto);
        }

        [HttpPut]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken)
        {
            var studentDto = await _studentService.UpdateAsync(studentId, studentForCreationDto, cancellationToken);

            return Ok(studentDto);
        }

        [HttpDelete]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId, CancellationToken cancellationToken)
        {
            await _studentService.DeleteAsync(studentId, cancellationToken);

            return NoContent();
        }
    }
}