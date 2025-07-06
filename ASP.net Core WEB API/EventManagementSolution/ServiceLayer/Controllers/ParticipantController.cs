using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantEventDetailsRepo<ParticipantEventDetails> _repo;

        public ParticipantController(IParticipantEventDetailsRepo<ParticipantEventDetails> repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var list = _repo.GetAllParticipantEventDetails();
            return list != null && list.Any() ? Ok(list) : NotFound();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var obj = _repo.GetParticipantEventDetailsById(id);
            return obj != null ? Ok(obj) : NotFound();
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ParticipantEventDetails obj)
        {
            if (ModelState.IsValid)
            {
                var added = _repo.AddParticipantEventDetails(obj);
                return Created(HttpContext.Request.Path, added);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ParticipantEventDetails obj)
        {
            if (ModelState.IsValid)
            {
                var updated = _repo.UpdateParticipantEventDetails(obj);
                return updated != null ? Accepted(HttpContext.Request.Path, updated) : NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var del = _repo.DeleteParticipantEventDetails(id);
            return del != null ? Ok(del) : NotFound();
        }
    }
}
