using DBAccess;
using Entity;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCandidateRepository();
            Console.ReadLine();
        }

        static async void TestCandidateRepository() 
        {
            Console.WriteLine("Insert name and gender to create a candidate");
            string name = Console.ReadLine().Trim();
            char gender = Console.ReadLine().ToCharArray()[0];

            using (InterviewDbContext context = new InterviewDbContext())
            {
                var repo = new CandidateRepository(context);
                await repo.GetAllAsync();

                var newCandidate = new Candidate()
                {
                    Name = name,
                    Gender = gender
                };

                await repo.AddAsync(newCandidate);
            }

            using (InterviewDbContext context = new InterviewDbContext()) 
            {
                var repo = new CandidateRepository(context);
                var newCandidate = new Candidate()
                {
                    Id = 3,
                    Name = "Annntony",
                    Gender = 'M'
                };
                await repo.UpdateAsync(newCandidate);
            }

            using (InterviewDbContext context = new InterviewDbContext())
            {
                var repo = new CandidateRepository(context);
                await repo.Remove(new Candidate { Id = 4 });
            }
        }

        static async void TestInterviewRepository() 
        {

        }
    }
}
