using Blogging.Repo.Models;

namespace Blogging.Repo.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get User by userName and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetUser(string userName, string password);
    }
}
