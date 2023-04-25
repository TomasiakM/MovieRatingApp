using Comments.Application.Dtos.Comment.Requests;
using Comments.Application.Features.Comments.Commands.Create;
using Comments.Application.Features.Comments.Commands.CreateReply;
using Mapster;

namespace Comments.Application.Mapper;
internal class CommentConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid resourceId, CreateCommentRequest request), CreateCommentCommand>()
            .Map(dest => dest.ResourseId, src => src.resourceId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<(Guid commenId, CreateReplyRequest request), CreateReplyCommand>()
            .Map(dest => dest.CommentId, src => src.commenId)
            .Map(dest => dest, src => src.request);
    }
}
