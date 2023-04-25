using Common.Domain.Exceptions;

namespace Comments.Domain.Exceptions.Comments;
public sealed class TimeToEditCommentHasExpiredExcpetion : DomainException
{
    public TimeToEditCommentHasExpiredExcpetion(int minutes) 
        : base($"Czas na edycję komentarza minął, edytować komentarz możesz edytować jedynie przez {minutes} minut")
    {
    }
}
