using Blogging.Repo.Models;
using Blogging.Service.Interfaces;
using Blogging.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogging.Controllers
{
    [Authorize]    
    public class BloggingController : ApiController
    {
        private readonly IBloggingService _bloggingRepositoryService;

        public BloggingController(IBloggingService bloggingRepositoryService)
        {
            _bloggingRepositoryService = bloggingRepositoryService;
        }

        [HttpPost]
        [Route("add/blog")]
        public void Post([FromBody]Blog blog)
        {
            _bloggingRepositoryService.AddBlog(blog);
        }

        [HttpPut]
        [Route("edit/blog")]
        public Blog Put([FromBody]Blog blog)
        {
            return _bloggingRepositoryService.EditBlog(blog);
        }

        [HttpDelete]
        [Route("delete/blog/{blogId}")]
        public void Delete(int blogId)
        {
            _bloggingRepositoryService.DeleteBlog(blogId);
        }

        [HttpGet]
        [Route("getAll/blogs")]
        public List<Blog> Get() => _bloggingRepositoryService.GetBlogs();






    }
}
