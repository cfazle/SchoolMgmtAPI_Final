using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Entities.Models;
using Entities.DataTransferObjects;
using SchoolMgmtAPI.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using SchoolMgmtAPI.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;

namespace SchoolMgmtAPI.Controllers
{

    [Route("api/organizations")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    // [ApiExplorerSettings(GroupName = "V1")]
    // [ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class OrganizationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public OrganizationController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of all organizations
        /// </summary>
        /// <returns>The organizations list</returns>
        [HttpGet(Name = "GetOrganizations")]

        public async Task <IActionResult> GetOrganizations()
        {

            var organizations = await _repository.Organization.GetAllOrganizationsAsync(trackChanges: false);
            //  return Ok(organizations);
            var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
            return Ok(organizationDto);

        }

        [HttpGet("{id}", Name = "OrganizationById")]
        //  [ResponseCache(Duration = 60)]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]

        public async Task <IActionResult> GetOrganization(Guid id)
        {

            var organization = await _repository.Organization.GetOrganizationAsync(id, trackChanges: false);
            if (organization == null)
            {
                _logger.LogInfo($"Organization with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var organizationDto = _mapper.Map<OrganizationDto>(organization);
                return Ok(organizationDto);
            }


        }

        [HttpGet("collection/({ids})", Name = "OrganizationCollection")]
        public async Task <IActionResult> GetOrganizationCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
        //  public IActionResult GetOrganizationCollection(IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            var organizationEntities =await _repository.Organization.GetByIdsAsync(ids, trackChanges: false);

            if (ids.Count() != organizationEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var organizationsToReturn = _mapper.Map<IEnumerable<OrganizationDto>>(organizationEntities);
            return Ok(organizationsToReturn);
        }


        /// <summary>
        /// Creates a newly created company
        /// </summary>
        /// <param name="organization"></param>
        /// <returns>A newly created organization</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateOrganization"), Authorize(Roles = "Administrator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task <IActionResult> CreateOrganization([FromBody] OrganizationForCreationDto organization)
        {
             var organizationEntity =  _mapper.Map<Organization>(organization);

            _repository.Organization.CreateOrganization(organizationEntity);

           await _repository.SaveAsync();

            var organizationToReturn = _mapper.Map<OrganizationDto>(organizationEntity);

            return CreatedAtRoute("OrganizationById",

                new { id = organizationToReturn.Id }, organizationToReturn);
        }

        [HttpPost("collection"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task < IActionResult> CreateOrganizationCollection([FromBody]
        IEnumerable<OrganizationForCreationDto> organizationCollection)
        {
          
            var organizationEntities = _mapper.Map<IEnumerable<Organization>>(organizationCollection);
            foreach (var organization in organizationEntities)
            {
                _repository.Organization.CreateOrganization(organization);
            }

           await _repository.SaveAsync();

            var organizationCollectionToReturn = _mapper.Map<IEnumerable<OrganizationDto>>
                (organizationEntities);
            var ids = string.Join(",", organizationCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("OrganizationCollection", new { ids }, organizationCollectionToReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateOrganizationExistsAttribute))]
        public async Task < IActionResult> DeleteOrganization(Guid id)
        {
            var organization = HttpContext.Items["organization"] as Organization;

            _repository.Organization.DeleteOrganization(organization);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateOrganizationExistsAttribute))]
        public async Task <IActionResult> UpdateOrganization(Guid id, [FromBody] OrganizationForUpdateDto organization)
        {
            

            var organizationEntity = HttpContext.Items["organization"] as Organization;

              _mapper.Map(organization, organizationEntity);
           await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateOrganizationExistsAttribute))]
        public async Task <IActionResult> PartiallyUpdateOrganization( Guid id, [FromBody] JsonPatchDocument<OrganizationForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }



          /*      var organizationEntity = await _repository.Organization.GetOrganizationAsync( id, trackChanges: true);
                if (organizationEntity == null)
              {
                    _logger.LogInfo($"Organization with id: {id} doesn't exist in the database.");
                    return NotFound();
                } */

            var organizationEntity = HttpContext.Items["organization"] as Organization;

            var organizationToPatch = _mapper.Map<OrganizationForUpdateDto>(organizationEntity);

            patchDoc.ApplyTo(organizationToPatch, ModelState);

            TryValidateModel(organizationToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(organizationToPatch, organizationEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");

            return Ok();
        }

    }
}
