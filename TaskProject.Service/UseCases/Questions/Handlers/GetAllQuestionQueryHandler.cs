using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskProject.Service.Abstractions.DataAccess;
using TaskProject.Service.UseCases.Questions.Queries;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace TaskProject.Service.UseCases.Questions.Handlers
{
    public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public GetAllQuestionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(GetAllQuestionQuery request, CancellationToken cancellationToken)
        {
            var questions = await _context.Questions.AsNoTracking().ToListAsync(cancellationToken);


            for (int i = 0; i < request.Number; i++)
            {
                var result = WriteQuestionsToFile(questions,  $"{request.Path}\\Question{i + 1}.docx");

                //File.WriteAllText(request.Path + $"\\Question{i + 1}.docx", result);
            }

            if (questions.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string WriteQuestionsToFile(List<Domain.Entities.Questions> questions, string docPath)
        {
            string value = "";

            Random random = new Random();

            var shuffledQuestions = questions.OrderBy(x => random.Next()).ToList();

            var randomQuestions = shuffledQuestions.ToList();

            int count = 1;

            foreach (var i in randomQuestions)
            {
                var variants = Shuffle(new List<string> { i.A, i.B, i.C, i.D });

                var answer = variants.FirstOrDefault(x => x.StartsWith("+"));

                value += "Question: " + i.Question + "\n";
                value += "A: " + variants[0] + "\n";
                value += "B: " + variants[1] + "\n";
                value += "C: " + variants[2] + "\n";
                value += "D: " + variants[3] + "\n";
                value += "Answer: " + answer + "\n\n";

                var res = File.Exists(docPath);

                if (!res)
                {
                    //File.AppendAllText($"{docPath}\\Question{count + 1}.docx",value);

                    using (DocX document = DocX.Create(docPath)) // Create a new document
                    {
                            // Add a paragraph for each item
                            Paragraph p = document.InsertParagraph();

                        if (i.ImagePath !=  "")
                        {
                            Image image = document.AddImage("wwwroot\\" + i.ImagePath);

                            // Add the image to the paragraph
                            Picture picture = image.CreatePicture();

                            p.InsertPicture(picture);
                        }

                            // Load the image from file
                            // Add description text
                            p.AppendLine(value).Bold();

                        // Save the document
                        document.Save();
                    }
                }
                else
                {
                    //File.AppendAllText($"{docPath}\\Question{count + 1}.docx",value);

                    using (DocX document = DocX.Load(docPath)) // Create a new document
                    {
                        // Add a paragraph for each item
                        Paragraph p = document.InsertParagraph();

                        // Load the image from file

                        if (i.ImagePath != "")
                        {
                        Image image = document.AddImage("wwwroot\\" + i.ImagePath);
                            // Add the image to the paragraph
                            Picture picture = image.CreatePicture();
                            p.InsertPicture(picture);


                        }

                        // Add description text
                        p.AppendLine(value).Bold();

                        // Save the document
                        document.Save();
                    }
                }
                value = "";

            }
            return value;
        }



        public List<T> Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}