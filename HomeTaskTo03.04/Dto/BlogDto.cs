using FluentValidation;

namespace HomeTaskTo03._04.Dto
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Description { get; set; }
        public int PostsCount { get; set; }
    }

    public class BlogValidator : AbstractValidator<BlogDto>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogName).Length(0, 10);
            RuleFor(x => x.Description).MaximumLength(50);
            RuleFor(x => x.PostsCount).GreaterThan(0);
        }
    }
}
