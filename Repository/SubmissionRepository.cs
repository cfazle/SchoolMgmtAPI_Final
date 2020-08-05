﻿using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class SubmissionRepository : RepositoryBase<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }

        public async Task<PagedList<Submission>> GetSubmissionsAsync(Guid assignmentId,
            SubmissionParameters submissionParameters, bool trackChanges)
        {
           var submission =  await FindByCondition(e => e.AssignmentId.Equals(assignmentId), trackChanges)
            .OrderBy(e => e.SubmissionTitle)
            .ToListAsync();

            return PagedList<Submission>
                .ToPagedList(submission, submissionParameters.PageNumber, submissionParameters.PageSize);
        }
        public async Task<IEnumerable<Submission>> GetSubmissionsAsync(Guid assignmentId, bool trackChanges) =>
          await FindByCondition(e => e.AssignmentId.Equals(assignmentId), trackChanges)
          .OrderBy(e => e.SubmissionTitle)
          .ToListAsync();


        public async Task <Submission> GetSubmissionAsync(Guid assignmentId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.AssignmentId.Equals(assignmentId) && e.Id.Equals(id), trackChanges)
          .SingleOrDefaultAsync();

     



        public void CreateSubmissionForAssignment(Guid assignmentId, Submission submission)
        {
            submission.AssignmentId = assignmentId;
            Create(submission);
        }

        public void DeleteSubmission(Submission submission)
        {
            Delete(submission);
        }

     
    }
}


