using DBAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class CandidateRepository : GenericRepository<Candidate, InterviewDbContext>
    {
        public CandidateRepository(InterviewDbContext context) : base(context)
        { 
        }
    }
}
