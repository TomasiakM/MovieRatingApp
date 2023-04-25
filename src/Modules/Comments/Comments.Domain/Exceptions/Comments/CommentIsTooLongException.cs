using Common.Domain.Exceptions;

namespace Comments.Domain.Exceptions.Comments;
public sealed class CommentIsTooLongException : DomainException
{
    public CommentIsTooLongException(int maxLength) 
        : base($"Maksymalna długość komentarza wynosi {maxLength}")
    {
    }
}
