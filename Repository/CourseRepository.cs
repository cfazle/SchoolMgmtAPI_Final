using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }




        public async Task<PagedList<Course>> GetCoursesAsync(Guid orgId, CourseParameters courseParameters,
            bool trackChanges)
        {
            var course = await FindByCondition(e => e.OrganizationId.Equals(orgId), trackChanges)
              .OrderBy(e => e.CourseName)       
              .ToListAsync();
              return PagedList<Course>
                   .ToPagedList(course, courseParameters.PageNumber, courseParameters.PageSize);
    }
        public async Task<IEnumerable<Course>> GetCoursesAsync(Guid orgId, bool trackChanges) =>
         await FindByCondition(e => e.OrganizationId.Equals(orgId), trackChanges)
         .OrderBy(e => e.CourseName)      
         .ToListAsync();

        public async Task<Course> GetCourseAsync(Guid orgId, Guid id, bool trackChanges)
        => await FindByCondition(e => e.OrganizationId.Equals(orgId) && e.Id.Equals(id), trackChanges)
               .SingleOrDefaultAsync();  



        public void CreateCourseForOrganization(Guid orgId, Course course)
        {
            course.OrganizationId = orgId;
            Create(course);
        }

        public void DeleteCourse(Course course)
        {
            Delete(course);
        }

     
    }   
}
