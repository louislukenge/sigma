using AutoMapper;
using CandidateManagementAPI.DTOs;
using CandidateManagementAPI.Models;

namespace CandidateManagementAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CandidateDto, Candidate>();
        }
    }
}
