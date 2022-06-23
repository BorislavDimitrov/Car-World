namespace CarWorld.Web.ViewModels.Posts
{
    using System;

    using AutoMapper;
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;
    using Ganss.XSS;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public string UserImagePath { get; set; }

    }
}
