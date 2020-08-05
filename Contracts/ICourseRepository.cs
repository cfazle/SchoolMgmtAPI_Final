using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICourseRepository
    {
        Task <PagedList<Course>> GetCoursesAsync(Guid orgId, CourseParameters courseParameters, bool trackChanges);

        Task<IEnumerable<Course>> GetCoursesAsync(Guid orgId, bool trackChanges);
        Task <Course> GetCourseAsync(Guid orgId, Guid id, bool trackChanges);

        void CreateCourseForOrganization(Guid orgId,Course course);
        void DeleteCourse(Course course);
    }
    
}
