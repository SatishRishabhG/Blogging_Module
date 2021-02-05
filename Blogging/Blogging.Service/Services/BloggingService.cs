using Blogging.Repo.Interfaces;
using Blogging.Repo.Models;
using Blogging.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Service.Services
{
    public class BloggingService : IBloggingService
    {
        private readonly IBloggingRepository _bloggingRepository;
        public BloggingService(IBloggingRepository bloggingRepository)
        {
            _bloggingRepository = bloggingRepository;
        }

        public void AddBlog(Blog blog)
        {
            _bloggingRepository.AddBlog(blog);
        }
        public Blog EditBlog(Blog blog) => _bloggingRepository.EditBlog(blog);

        public void DeleteBlog(int blogId)
        {
            _bloggingRepository.DeleteBlog(blogId);
        }
        public List<Blog> GetBlogs() => _bloggingRepository.GetBlogs();

    }
}
