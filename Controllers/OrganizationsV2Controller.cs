using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolMgmtAPI.Controllers
{

    [Route("api/organizations")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "V2")]
    public class OrganizationsV2Controller : ControllerBase
    {

        private readonly IRepositoryManager _repository;

        public OrganizationsV2Controller(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            var organizations = await _repository.Organization.GetAllOrganizationsAsync(trackChanges: false);

            return Ok(organizations);
        }
    }
}