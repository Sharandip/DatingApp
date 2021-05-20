using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseAPIController
    {
        private readonly DataContext _context;
        public ErrorController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret String";
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var found = this._context.Users.Find(-1);
            return found.ToString();
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var found = this._context.Users.Find(-1);
            if (found == null)
                return NotFound();
            return Ok(found);
        }
        [HttpGet("bad-request")]
        public ActionResult GetBadrequest()
        {
            return BadRequest("This is a bad request!");
        }
    }
}