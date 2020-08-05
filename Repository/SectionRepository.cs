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
    class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }


        public async Task<PagedList<Section>> GetSectionsAsync(Guid courseId, SectionParameters
            sectionParameters, bool trackChanges)
        {
            var section = await FindByCondition(e => e.CourseId.Equals(courseId), trackChanges)
                 .OrderBy(e => e.Type)
                 .ToListAsync();
            return PagedList<Section>
                .ToPagedList(section, sectionParameters.PageNumber, sectionParameters.PageSize);
        }

        public async Task<IEnumerable<Section>> GetSectionsAsync(Guid courseId,  bool trackChanges) =>
        await FindByCondition(e => e.CourseId.Equals(courseId), trackChanges)
           .OrderBy(e => e.Type)
           .ToListAsync();


        public async Task<Section> GetSectionAsync(Guid courseId, Guid id, bool trackChanges) => 
            await FindByCondition(e => e.CourseId.Equals(courseId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();



        public void CreateSectionForCourse(Guid courseId, Section section)
        {
            section.CourseId = courseId;
            Create(section);
        }

        public void DeleteSection(Section section)
        {
            Delete(section);
        }

       

      
    }
}
   
