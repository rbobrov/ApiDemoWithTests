using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {
        [Route("/")]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "<div>Hello world!</div>";
        }

        [Route("/{id}")]
        [HttpGet]
        public ActionResult<string> GetById(int id)
        {
            return $"ИД={id + 1}";
        }
    }
}
