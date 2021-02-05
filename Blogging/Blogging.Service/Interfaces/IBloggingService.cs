using Blogging.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Service.Interfaces
{
    public interface IBloggingService
    {
        /// <summary>
        /// To add a Blog
        /// </summary>
        /// <param name="blog"></param>
        void AddBlog(Blog blog);

        /// <summary>
        /// To edit a Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        Blog EditBlog(Blog blog);

        /// <summary>
        /// To Delete a blog
        /// </summary>
        /// <param name="blogId"></param>
        void DeleteBlog(int blogId);

        /// <summary>
        /// To get all the blogs
        /// </summary>
        /// <returns></returns>
        List<Blog> GetBlogs();
    }
}
