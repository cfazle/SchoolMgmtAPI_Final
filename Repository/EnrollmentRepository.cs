using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<PagedList<Enrollment>> GetEnrollmentsAsync(Guid sectionId,
            EnrollmentParameters enrollmentParameters, bool trackChanges)
        {
           var enrollment = await FindByCondition(e => e.SectionId.Equals(sectionId), trackChanges)
        .OrderBy(e => e.AttributeName)
          .ToListAsync();

            return PagedList<Enrollment>
                .ToPagedList(enrollment, enrollmentParameters.PageNumber, enrollmentParameters.PageSize);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsAsync(Guid sectionId,  bool trackChanges) =>
        await FindByCondition(e => e.SectionId.Equals(sectionId), trackChanges)
        .OrderBy(e => e.AttributeName)
        .ToListAsync();

        public async Task<Enrollment> GetEnrollmentAsync(Guid sectionId, Guid id, bool trackChanges)=> 
            await FindByCondition(e => e.SectionId.Equals(sectionId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


           

        public void CreateEnrollmentForSection(Guid sectionId, Enrollment enrollment)
        {
            enrollment.SectionId = sectionId;
            Create(enrollment);
        }

        public void DeleteEnrollment(Enrollment enrollment)
        {
           Delete(enrollment);
        }

       
    }
}
   

