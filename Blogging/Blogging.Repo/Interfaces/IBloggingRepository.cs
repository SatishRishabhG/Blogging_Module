using Blogging.Repo.Models;
using System.Collections.Generic;

namespace Blogging.Repo.Interfaces
{
    public interface IBloggingRepository
    {
        /// <summary>
        /// To add a blog
        /// </summary>
        /// <param name="blog"></param>
        void AddBlog(Blog blog);

        /// <summary>
        /// This is to edit a blog on behalf of blogId
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        Blog EditBlog(Blog blog);

        /// <summary>
        /// This is to delete the Blog by blogId
        /// </summary>
        /// <param name="blogId"></param>
        void DeleteBlog(int blogId);
        /// <summary>
        /// To get all the Blogs list
        /// </summary>
        /// <returns></returns>
        List<Blog> GetBlogs();
    }
}
