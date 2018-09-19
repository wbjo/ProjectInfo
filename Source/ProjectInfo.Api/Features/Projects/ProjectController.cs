using Appeaser;
using Microsoft.AspNetCore.Mvc;
using ProjectInfo.Api.Features.Projects.Business;

namespace ProjectInfo.Api.Features.Projects
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok(_mediator.Request(new GetProjects.Query())); 
        }
    }
}