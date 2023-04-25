using Common.Domain.Exceptions;

namespace Comments.Domain.Exceptions.Comments;
public sealed class UserCannotUpdateSomeoneCommentException : DomainException
{
    public UserCannotUpdateSomeoneCommentException() 
        : base("Ten komentarz nie jest twój, nie możesz go edytować")
    {
    }
}
