using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISectionRepository
    {
       Task <PagedList<Section>> GetSectionsAsync(Guid courseId, SectionParameters sectionparameters,bool trackChanges);

        Task<IEnumerable<Section>> GetSectionsAsync(Guid courseId, bool trackChanges);
        Task <Section> GetSectionAsync(Guid courseId, Guid id, bool trackChanges);

        void CreateSectionForCourse(Guid courseId, Section section);
        void DeleteSection(Section section);
    }
}
