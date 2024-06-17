
using AutoMapper;
using CandidateManagementAPI.DTOs;
using CandidateManagementAPI.Interface;
using CandidateManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CandidateManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : Controller
    {
        private readonly CandidateInterface _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateController(CandidateInterface candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Candidate>))]
        public IActionResult GetCandidates() 
        {
            var candidates = _mapper.Map<List<Candidate>>(_candidateRepository.GetCandidates());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(candidates);
        }
        [HttpGet("{Email}")]
        [ProducesResponseType(200, Type =typeof(Candidate))]
        [ProducesResponseType(400)]
        public IActionResult GetCandidate(string Email)
        {
            if (!_candidateRepository.CandidateExists(Email))
                return NotFound();

            var candidate = _mapper.Map<Candidate>(_candidateRepository.GetCandidate(Email));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(candidate);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateCandidate([FromBody] CandidateDto candidateCreate) 
        {
            if(candidateCreate == null)
                return BadRequest(ModelState);

            var candidate = _candidateRepository.GetCandidates()
                .Where(c => c.Email.Trim().ToLower() == candidateCreate.Email.TrimEnd().ToLower())
                .FirstOrDefault();

            if(candidate != null) 
            {
                ModelState.AddModelError("", "Candidate already exists");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid) { return BadRequest(ModelState); }

            var candidateMap = _mapper.Map<Candidate>(candidateCreate);

            if (!_candidateRepository.CreateCandidate(candidateMap)) 
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpPut("{Email}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCandidate(string Email, [FromBody] CandidateDto updatedCandidate) 
        {
            if(updatedCandidate == null)
                return BadRequest(ModelState);

            if(Email != updatedCandidate.Email)
                return BadRequest(ModelState);

            if (!_candidateRepository.CandidateExists(Email))
                return NotFound();

            if(!ModelState.IsValid) { return BadRequest(); }

            var candidateMap = _mapper.Map<Candidate>(updatedCandidate);
            if (!_candidateRepository.UpdateCandidate(candidateMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{Email}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCandidate(string Email) 
        {
            if (!_candidateRepository.CandidateExists(Email))
            {
                return NotFound();
            }

            var candidateToDelete = _candidateRepository.GetCandidate(Email);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_candidateRepository.DeleteCandidate(candidateToDelete)) 
            {
                ModelState.AddModelError("", "Something went wrong while deleting candidate");
            }

            return NoContent();
        }
    }
}
