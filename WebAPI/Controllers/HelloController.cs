using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {
        WebAPIContext _context;

        public HelloController(WebAPIContext context)
        {
            _context = context;
        }

        [Route("/")]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return  _context.Counters.Select(c => c.Value).First();
            //return "<div>Hello world!</div>";
        }

        [Route("/{id}")]
        [HttpGet]
        public ActionResult<string> GetById(int id)
        {
            return $"ИД={id + 1}";
        }
    }
}
