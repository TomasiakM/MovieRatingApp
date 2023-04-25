using Common.Domain.Exceptions;

namespace Comments.Domain.Exceptions.Comments;
public sealed class CommentIsTooShortException : DomainException
{
    public CommentIsTooShortException(int minLength) 
        : base($"Komentarz musi mieć {minLength} znaków")
    {
    }
}
