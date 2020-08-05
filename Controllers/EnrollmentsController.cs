using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolMgmtAPI.ActionFilters;

namespace SchoolMgmtAPI.Controllers
{
    [Route("api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EnrollmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet, Authorize(Roles = "Administrator")]
        public async Task < IActionResult> GetEnrollmentsForSection(Guid sectionId, [FromQuery] 
       EnrollmentParameters enrollmentParameters )

        {
            var section = await _repository.Section.GetSectionsAsync(sectionId,  trackChanges: false);

            if (section == null)
            {
                _logger.LogInfo($"Section with id: {sectionId} doesn't exist in the database.");
                return NotFound();
            }

            var enrollmentsFromDb = await _repository.Enrollment.GetEnrollmentsAsync(sectionId, enrollmentParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(enrollmentsFromDb.MetaData));
            var enrollmentsDto = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollmentsFromDb);

            return Ok(enrollmentsDto);
        }

        [HttpGet("{id}"), Authorize(Roles = "Administrator")]
        public async Task <IActionResult> GetEnrollmentForSection(Guid sectionId, Guid id)
        {
            var organization = await _repository.Section.GetSectionsAsync(sectionId,  trackChanges: false);
            if (organization == null)
            {
                _logger.LogInfo($"Section with id: {sectionId} doesn't exist in the database.");
                return NotFound();
            }

            var enrollmentDb =await _repository.Enrollment.GetEnrollmentAsync(sectionId, id, trackChanges: false);
            if (enrollmentDb == null)
            {
                _logger.LogInfo($"Enrollment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var enrollment = _mapper.Map<EnrollmentDto>(enrollmentDb);

            return Ok(enrollment);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task < IActionResult> CreateEnrollmentForSection(Guid sectionId, [FromBody] EnrollmentForCreationDto enrollment)
        {
          

            var enrollmentEntity = _mapper.Map<Enrollment>(enrollment);         

            _repository.Enrollment.CreateEnrollmentForSection(sectionId, enrollmentEntity);
           await _repository.SaveAsync();

            var enrollmentToReturn = _mapper.Map<EnrollmentDto>(enrollmentEntity);

            return CreatedAtRoute(new { sectionId, id = enrollmentToReturn.Id }, enrollmentToReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateEnrollmentExistsAttribute))]
        public async Task <IActionResult> DeleteEnrollmentForSection(Guid sectionId, Guid id)
        {
   
            var enrollmentForSection = HttpContext.Items["enrollment"] as Enrollment;
            _repository.Enrollment.DeleteEnrollment(enrollmentForSection);
           await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateEnrollmentExistsAttribute))]
        public async Task <IActionResult> UpdateEnrollmentForSection(Guid sectionId, Guid id, [FromBody] EnrollmentForUpdateDto enrollment)
        {
           
            var enrollmentEntity = HttpContext.Items["enrollment"] as Enrollment;
            
            _mapper.Map(enrollment, enrollmentEntity);

           await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateEnrollmentExistsAttribute))]
        public async Task < IActionResult> PartiallyUpdateEnrollmentForSection(Guid sectionId, Guid id, [FromBody] JsonPatchDocument<EnrollmentForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

           
            var enrollmentEntity = HttpContext.Items["enrollment"] as Enrollment;
            var enrollmentToPatch = _mapper.Map<EnrollmentForUpdateDto>(enrollmentEntity);

            patchDoc.ApplyTo(enrollmentToPatch, ModelState);

            TryValidateModel(enrollmentToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            patchDoc.ApplyTo(enrollmentToPatch);

            _mapper.Map(enrollmentToPatch, enrollmentEntity);

           await _repository.SaveAsync();

            return NoContent();
        }
    }
}
