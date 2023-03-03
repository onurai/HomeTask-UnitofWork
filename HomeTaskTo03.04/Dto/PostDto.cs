using FluentValidation;

namespace HomeTaskTo03._04.Dto
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int BlogId { get; set; }
    }

    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).Length(0, 15);
            RuleFor(x => x.Subtitle).Length(0, 15);
            RuleFor(x => x.Content).Length(0, 15);
            RuleFor(x => x.Description).Length(0, 15);
        }
    }
}
