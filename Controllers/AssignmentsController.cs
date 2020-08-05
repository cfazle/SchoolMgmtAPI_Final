using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolMgmtAPI.ActionFilters;

namespace SchoolMgmtAPI.Controllers
{
    [Route("api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments" +
        "/{enrollmentId}/assignments")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AssignmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetAssignmentsForEnrollment(Guid enrollmentId, [FromQuery]
        AssignementParametes assignementParametes)

        {
            var enrollment = await _repository.Enrollment.GetEnrollmentsAsync(enrollmentId,  trackChanges: false);

            if (enrollment == null)
            {
                _logger.LogInfo($"Enrollment with id: {enrollmentId} doesn't exist in the database.");
                return NotFound();
            }

            var assignmentsFromDb = await _repository.Assignment.GetAssignmentsAsync(enrollmentId, assignementParametes, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(assignmentsFromDb.MetaData));

            var assignmentsDto = _mapper.Map<IEnumerable<AssignmentDto>>(assignmentsFromDb);

            return Ok(assignmentsDto);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetAssinmentForSection(Guid enrollmentId, Guid id)
        {
            var enrollment = await _repository.Enrollment.GetEnrollmentsAsync(enrollmentId,  trackChanges: false);
            if (enrollment == null)
            {
                _logger.LogInfo($"Enrollment with id: {enrollmentId} doesn't exist in the database.");
                return NotFound();
            }

            var assignmentDb = await _repository.Assignment.GetAssignmentAsync(enrollmentId, id, trackChanges: false);
            if (assignmentDb == null)
            {
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var assignment = _mapper.Map<AssignmentDto>(assignmentDb);

            return Ok(assignment);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task <IActionResult> CreateAssinmentForEnrollment(Guid enrollmentId, [FromBody] AssignmentForCreationDto assignment)
        {
          
            var assignmentEntity = _mapper.Map<Assignment>(assignment);

            //      _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);

            _repository.Assignment.CreateAssignmentForEnrollment(enrollmentId, assignmentEntity);
           await  _repository.SaveAsync();

            var assignmentToReturn = _mapper.Map<AssignmentDto>(assignmentEntity);

            return CreatedAtRoute(new { enrollmentId, id = assignmentToReturn.Id }, assignmentToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateAssignmentExistsAttribute))]
        public async Task <IActionResult> DeleteAssignmenttForEnrollment(Guid enrollmentId, Guid id)
        {
            

            var assignmentForEnrollment = HttpContext.Items["assignment"] as Assignment;

            _repository.Assignment.DeleteAssignment(assignmentForEnrollment);
          await  _repository.SaveAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateAssignmentExistsAttribute))]
        public async Task <IActionResult> UpdateAssignmentForEnrollment(Guid enrollmentId, Guid id, [FromBody] AssignmentForUpdateDto assignment)
        {
       
            var assignmentEntity = HttpContext.Items["assignment"] as Assignment;

            _mapper.Map(assignment, assignmentEntity);
           await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateAssignmentExistsAttribute))]
        public async Task < IActionResult> PartiallyUpdateAssignmentForEnrollment(Guid enrollmentId, Guid id, [FromBody] JsonPatchDocument<AssignmentForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

           

            var assignmentEntity = HttpContext.Items["assignment"] as Assignment;
            var assignmentToPatch = _mapper.Map<AssignmentForUpdateDto>(assignmentEntity);

            patchDoc.ApplyTo(assignmentToPatch, ModelState);

            TryValidateModel(assignmentToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            patchDoc.ApplyTo(assignmentToPatch);

            _mapper.Map(assignmentToPatch, assignmentEntity);

          await  _repository.SaveAsync();

            return NoContent();
        }
    }
}
