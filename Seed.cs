using CandidateManagementAPI.Data;
using CandidateManagementAPI.Models;

namespace CandidateManagementAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext() 
        {
            if(!dataContext.Candidates.Any())
            {
                dataContext.Candidates.AddRange(new Candidate()
                {
                    FirstName = "Mark",
                    LastName = "Kifure",
                    Email = "kifure@gmail.com",
                    FreeTextComment = "Ever challenged but never equalled",
                    PhoneNumber= 0706777666,
                    GithubProfileURL= "https://github.com/",
                    LinkedIn = "https://www.linkedin.com/login",
                    PreferredCallTimeInterval="8:00am-5:00pm"
                }, new Candidate()
                {
                    FirstName = "Mark",
                    LastName = "Kigozi",
                    Email = "kigozi@gmail.com",
                    FreeTextComment = "Ever challenged but never equalled",
                    PhoneNumber = 0706777888,
                    GithubProfileURL = "https://github.com/",
                    LinkedIn = "https://www.linkedin.com/login",
                    PreferredCallTimeInterval = "10:00am-5:00pm"
                }

                );
                dataContext.SaveChanges();
            }
        }
    }
}
