using MediatR;

namespace TaskProject.Service.UseCases.Questions.Queries
{
    public class GetAllQuestionQuery : IRequest<bool>
    {
        public int Number { get; set; }
        public string Path { get; set; }
    }
}