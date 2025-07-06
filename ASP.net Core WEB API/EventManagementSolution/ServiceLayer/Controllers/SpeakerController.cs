using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SpeakersDetailsController : ControllerBase
    {
        private readonly ISpeakersDetailsRepo<SpeakersDetails> _speakerRepo;

        public SpeakersDetailsController(ISpeakersDetailsRepo<SpeakersDetails> speakerRepo)
        {
            _speakerRepo = speakerRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllSpeakers()
        {
            var speakers = _speakerRepo.GetAllSpeakerDetails();
            if (speakers != null && speakers.Any())
                return Ok(speakers);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetSpeakerById(int id)
        {
            var speaker = _speakerRepo.GetSpeakerDetailsById(id);
            if (speaker != null)
                return Ok(speaker);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddSpeaker([FromBody] SpeakersDetails speaker)
        {
            if (ModelState.IsValid)
            {
                var added = _speakerRepo.AddSpeakerDetails(speaker);
                return Created(HttpContext.Request.Path, added);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateSpeaker([FromBody] SpeakersDetails speaker)
        {
            if (ModelState.IsValid)
            {
                var updated = _speakerRepo.UpdateSpeakerDetails(speaker);
                if (updated != null)
                    return Accepted(HttpContext.Request.Path, updated);
                else
                    return NotFound();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteSpeaker(int id)
        {
            var deleted = _speakerRepo.DeleteSpeakerDetails(id);
            if (deleted != null)
                return Ok(deleted);
            else
                return NotFound();
        }
    }
}
