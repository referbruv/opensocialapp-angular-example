using System;

namespace OpenSocialApp.Api.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public PostType Type { get; set; }
        public DateTime PostedOn { get; set; }
        public string AssetUrl { get; set; }
        public string PostedBy { get; set; }
    }

    public class NewPostRequest
    {
        public string Text { get; set; }
        public PostType Type { get; set; }
        public string AssetUrl { get; set; }
        public string PostedBy { get; set; }
    }

    public enum PostType
    {
        Status,
        Image,
        Video
    }
}