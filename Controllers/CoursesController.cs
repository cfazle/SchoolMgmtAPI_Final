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
using Nest;
using Newtonsoft.Json;
using SchoolMgmtAPI.ActionFilters;
using SchoolMgmtAPI.Utility;

namespace SchoolMgmtAPI.Controllers
{
    [Route("api/organizations/{orgId}/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly CourseLinks _courseLinks;

        public CoursesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
            CourseLinks courseLinks)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _courseLinks = courseLinks;
        }

        [HttpGet]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task <IActionResult> GetCoursesForOrganization(Guid orgId, [FromQuery]
        CourseParameters courseParameters)

        {
            
            var organization = await _repository.Organization.GetOrganizationAsync(orgId,  trackChanges: false);

            if (organization == null)
            {
                _logger.LogInfo($"Organization with id: {orgId} doesn't exist in the database.");
                return NotFound();
            } 

            var coursesFromDb =await _repository.Course.GetCoursesAsync(orgId,  courseParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(coursesFromDb.MetaData));
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(coursesFromDb);

            //   return Ok(coursesDto);

            var links = _courseLinks.TryGenerateLinks(coursesDto, courseParameters.Fields, orgId, HttpContext);

            return links.HasLinks ? Ok(links.LinkedEntities) : Ok(links.ShapedEntities);
        }

       //    [HttpGet("{id}", Name = "GetCourseForUser")]

       [HttpGet("{id}")]
        public async Task <IActionResult> GetCourseForOrganizatio(Guid orgId, Guid id)
          
        {
            var user = await _repository.Organization.GetOrganizationAsync(orgId,  trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {orgId} doesn't exist in the database.");
                return NotFound();
            } 

            var courseDb =await _repository.Course.GetCourseAsync(orgId, id, trackChanges: false);
            if (courseDb == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var course = _mapper.Map<CourseDto>(courseDb);

            return Ok(course);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task <IActionResult> CreateCourseForOrganization( Guid orgId, [FromBody]
        CourseForCreationDto course)
        {
         
            var courseEntity = _mapper.Map<Course>(course);

           _repository.Course.CreateCourseForOrganization(orgId, courseEntity);
           await _repository.SaveAsync();

            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return CreatedAtRoute( new { orgId, id = courseToReturn.Id }, courseToReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateCourseExistsAttribute))]
        public async Task <IActionResult> DeleteCourseForOrganization(Guid orgId, Guid id)
        {
           
            var courseForUser = HttpContext.Items["course"] as Course;

            _repository.Course.DeleteCourse(courseForUser);

           await _repository.SaveAsync();

            return NoContent();


        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCourseExistsAttribute))]
        public async Task <IActionResult> UpdateCourseForOrganization(Guid orgId, Guid id, [FromBody] 
        CourseForUpdateDto course)
        {
         

            var courseEntity = HttpContext.Items["Course"] as Course;

            _mapper.Map(course, courseEntity);
          await  _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateCourseExistsAttribute))]
        public async Task <IActionResult> PartiallyUpdateCourseForOrganization(Guid orgId, 
            Guid id, [FromBody] JsonPatchDocument<CourseForUpdateDto> patchDoc)
        {
          
         

            var courseEntity = HttpContext.Items["course"] as Course;

            var courseToPatch = _mapper.Map<CourseForUpdateDto>(courseEntity);

            patchDoc.ApplyTo(courseToPatch, ModelState);

            TryValidateModel(courseToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            //    patchDoc.ApplyTo(courseToPatch);

            _mapper.Map(courseToPatch, courseEntity);

           await _repository.SaveAsync();

            return NoContent();
        }


    }
}
