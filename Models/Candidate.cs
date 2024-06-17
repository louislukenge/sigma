namespace CandidateManagementAPI.Models
{
    public class Candidate
    {
        public Candidate()
        {
            // Initialize non-nullable properties in the constructor
            FirstName = "";
            LastName = "";
            Email = "";
            FreeTextComment = "";
            GithubProfileURL = "";
            LinkedIn = "";
            PhoneNumber = 0;
            PreferredCallTimeInterval = "";
        }

        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FreeTextComment { get; set; }
        public string LinkedIn { get; set; }
        public string GithubProfileURL { get; set; }
        public string PreferredCallTimeInterval { get; set; }

    }
}
