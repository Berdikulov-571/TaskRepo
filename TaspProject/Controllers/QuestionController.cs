using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskProject.Service.UseCases.Questions.Queries;

namespace TaskProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> GetAllAsync([FromForm]GetAllQuestionQuery command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
