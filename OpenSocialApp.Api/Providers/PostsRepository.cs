using System;
using System.Collections.Generic;
using System.Linq;
using OpenSocialApp.Api.Models;

namespace OpenSocialApp.Api.Providers
{
    public class PostsRepository
    {
        private static List<Post> _posts;
        
        public PostsRepository()
        {
        }

        static PostsRepository()
        {
            _posts = new List<Post>()
            {
            };
        }

        public IEnumerable<Post> All()
        {
            return _posts.OrderByDescending(x => x.PostedOn);
        }

        public Post FindById(Guid id)
        {
            return _posts.Where(x => x.Id == id).FirstOrDefault();
        }

        public Post Add(NewPostRequest newPost)
        {
            var post = new Post();
            post.Id = Guid.NewGuid();
            post.PostedOn = DateTime.Now;
            post.PostedBy = newPost.PostedBy;
            post.Text = newPost.Text;
            post.Type = newPost.Type;
            post.AssetUrl = newPost.AssetUrl;
            _posts.Add(post);
            return post;
        }
    }
}