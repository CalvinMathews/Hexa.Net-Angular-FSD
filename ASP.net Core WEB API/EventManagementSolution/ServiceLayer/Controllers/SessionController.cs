using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SessionInfoController : ControllerBase
    {
        private readonly ISessionInfoRepo<Session> _sessionRepo;

        public SessionInfoController(ISessionInfoRepo<Session> sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllSessions()
        {
            var sessions = _sessionRepo.GetAllSessionInfo();
            if (sessions != null && sessions.Any())
                return Ok(sessions);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetSessionById(int id)
        {
            var session = _sessionRepo.GetSessionInfoById(id);
            if (session != null)
                return Ok(session);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddSession([FromBody] Session session)
        {
            if (ModelState.IsValid)
            {
                var added = _sessionRepo.AddSessionInfo(session);
                return Created(HttpContext.Request.Path, added);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateSession([FromBody] Session session)
        {
            if (ModelState.IsValid)
            {
                var updated = _sessionRepo.UpdateSessionInfo(session);
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
        public IActionResult DeleteSession(int id)
        {
            var deleted = _sessionRepo.DeleteSessionInfo(id);
            if (deleted != null)
                return Ok(deleted);
            else
                return NotFound();
        }
    }
}
