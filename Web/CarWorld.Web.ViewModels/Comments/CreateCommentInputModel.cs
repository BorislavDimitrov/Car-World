using CarWorld.Data.Models;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Comments
{
    public class CreateCommentInputModel : IMapTo<Comment>
    {
        public string Content { get; set; }

        public int PostId { get; set; }

        public int? ParentId { get; set; }

        public string UserId { get; set; }
    }
}
