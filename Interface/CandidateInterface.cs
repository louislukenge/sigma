using CandidateManagementAPI.Models;

namespace CandidateManagementAPI.Interface
{
    public interface CandidateInterface
    {
        ICollection<Candidate> GetCandidates();
        Candidate GetCandidate(string email);

        bool CandidateExists(string candidateEmail);
        bool CreateCandidate(Candidate candidate);
        bool UpdateCandidate(Candidate candidate);
        bool DeleteCandidate(Candidate candidate);
        bool Save();
    }
}
