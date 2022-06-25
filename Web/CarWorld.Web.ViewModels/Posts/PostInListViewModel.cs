using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace CarWorld.Web.ViewModels.Posts
{
    public class PostInListViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 300
                        ? content.Substring(0, 300) + "..."
                        : content;
            }
        }

        public string CreatorUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
