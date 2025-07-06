using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventDetailsRepo<EventDetails> _repo;

        public EventController(IEventDetailsRepo<EventDetails> repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _repo.GetAllEvents();
            return data != null ? Ok(data) : NotFound();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var item = _repo.GetEventsById(id);
            return item != null ? Ok(item) : NotFound();
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] EventDetails obj)
        {
            if (obj != null)
            {
                _repo.AddEvent(obj);
                return Created(HttpContext.Request.Path, obj);
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] EventDetails obj)
        {
            var updated = _repo.UpdateEvent(obj);
            return updated != null ? Accepted(HttpContext.Request.Path, updated) : BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var del = _repo.DeleteEvent(id);
            return del != null ? Ok(del) : NotFound();
        }
    }
}
