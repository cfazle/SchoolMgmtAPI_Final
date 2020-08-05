﻿using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubmissionRepository
    {
        Task <PagedList<Submission>> GetSubmissionsAsync(Guid assignmentId, SubmissionParameters submissionParameters, bool trackChanges);

        Task<IEnumerable<Submission>> GetSubmissionsAsync(Guid assignmentId, bool trackChanges);
        Task <Submission> GetSubmissionAsync(Guid assignmentId, Guid id, bool trackChanges);

        void CreateSubmissionForAssignment(Guid assignmentId, Submission submission);
        void DeleteSubmission(Submission submission);

    }
}
