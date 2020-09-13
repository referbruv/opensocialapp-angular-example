using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenSocialApp.Api.Models;
using OpenSocialApp.Api.Providers;

namespace OpenSocialApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostsRepository _repo;

        public PostsController()
        {
            _repo = new PostsRepository();
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _repo.All();
        }

        [HttpGet, Route("{id}")]
        public Post Get(Guid id)
        {
            return _repo.FindById(id);
        }

        [Authorize]
        [HttpPost]
        public Post Post([FromBody] NewPostRequest post)
        {
            var sub = User.FindFirst(ClaimTypes.GivenName); //.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            if (sub != null)
            {
                post.PostedBy = sub.Value.ToString();
            }
            else
            {
                post.PostedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            return _repo.Add(post);
        }
    }
}
