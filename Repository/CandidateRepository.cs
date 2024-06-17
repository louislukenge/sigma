using CandidateManagementAPI.Data;
using CandidateManagementAPI.Interface;
using CandidateManagementAPI.Models;


namespace CandidateManagementAPI.Repository
{
    
    public class CandidateRepository : CandidateInterface
    {
        private readonly DataContext _context;
        public CandidateRepository(DataContext context) {  _context = context; }



        ICollection<Candidate> CandidateInterface.GetCandidates()
        {
            return _context.Candidates.OrderBy(p => p.Email).ToList();
        }

        Candidate CandidateInterface.GetCandidate(string email)
        {
            return _context.Candidates.Where(p => p.Email == email).FirstOrDefault();
        }

        bool CandidateInterface.CandidateExists(string candidateEmail)
        {
            return _context.Candidates.Any(p => p.Email == candidateEmail);
        }

       

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateCandidate(Candidate candidate)
        {
            // Change Tracker
            // add, updating, modifying
            // connected vs disconnected
            // EntityState.Added
            _context.Add(candidate);
            return Save();
        }

        public bool UpdateCandidate(Candidate candidate)
        {
            _context.Update(candidate);
            return Save();
        }

        public bool DeleteCandidate(Candidate candidate)
        {
            _context.Remove(candidate);
            return Save();
        }
    }
}
