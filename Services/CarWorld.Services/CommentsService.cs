using AutoMapper;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Comments;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepo;
        private readonly IMapper mapper;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepo)
        {
            this.commentsRepo = commentsRepo;
            this.mapper = this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task CreateComment(CreateCommentInputModel model)
        {
            var newComment = mapper.Map<Comment>(model);

            await commentsRepo.AddAsync(newComment);
            await commentsRepo.SaveChangesAsync();
        }

        public async Task<bool> IsCommentInPost(int? parentId, int postId)
        {
            var comment = await commentsRepo.All()
                .FirstOrDefaultAsync(x => x.Id == parentId);

            return comment.PostId == postId;
        }
    }
}
