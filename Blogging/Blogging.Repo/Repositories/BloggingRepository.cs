using Blogging.Repo.Interfaces;
using Blogging.Repo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Repo.Repositories
{
    public class BloggingRepository : IBloggingRepository
    {
        SqlConnection _sqlConnection;
        public BloggingRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            _sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["GrapeCityBloggingEntities"].ConnectionString;
        }

        public void AddBlog(Blog blog)
        {
            try
            {
                using (_sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "add_blog";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = _sqlConnection;

                    SqlParameter titleParameter = new SqlParameter();
                    titleParameter.ParameterName = "@title";
                    titleParameter.SqlDbType = SqlDbType.NVarChar;
                    titleParameter.Direction = ParameterDirection.Input;
                    titleParameter.Value = blog.Title;

                    SqlParameter contentParameter = new SqlParameter();
                    contentParameter.ParameterName = "@content";
                    contentParameter.SqlDbType = SqlDbType.NVarChar;
                    contentParameter.Direction = ParameterDirection.Input;
                    contentParameter.Value = blog.Content;

                    SqlParameter userParameter = new SqlParameter();
                    userParameter.ParameterName = "@userid";
                    userParameter.SqlDbType = SqlDbType.Int;
                    userParameter.Direction = ParameterDirection.Input;
                    userParameter.Value = blog.UserId;

                    sqlCommand.Parameters.Add(titleParameter);
                    sqlCommand.Parameters.Add(contentParameter);
                    sqlCommand.Parameters.Add(userParameter);

                    _sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                _sqlConnection.Close();
            }

        }
        public Blog EditBlog(Blog blog)
        {
            try
            {
                using (_sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "edit_blog";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = _sqlConnection;

                    SqlParameter titleParameter = new SqlParameter();
                    titleParameter.ParameterName = "@title";
                    titleParameter.SqlDbType = SqlDbType.NVarChar;
                    titleParameter.Direction = ParameterDirection.Input;
                    titleParameter.Value = blog.Title;

                    SqlParameter contentParameter = new SqlParameter();
                    contentParameter.ParameterName = "@content";
                    contentParameter.SqlDbType = SqlDbType.NVarChar;
                    contentParameter.Direction = ParameterDirection.Input;
                    contentParameter.Value = blog.Content;

                    SqlParameter blogIdParameter = new SqlParameter();
                    blogIdParameter.ParameterName = "@blogid";
                    blogIdParameter.SqlDbType = SqlDbType.NVarChar;
                    blogIdParameter.Direction = ParameterDirection.Input;
                    blogIdParameter.Value = blog.BlogId;

                    sqlCommand.Parameters.Add(titleParameter);
                    sqlCommand.Parameters.Add(contentParameter);
                    sqlCommand.Parameters.Add(blogIdParameter);

                    _sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dtBlog = new DataTable();
                    dataAdapter.Fill(dtBlog);

                    return dtBlog.AsEnumerable().Select(user => new Blog()
                    {
                        BlogId = Convert.ToInt32(user["BlogId"]),
                        Title = Convert.ToString(user["Title"]),
                        Content = Convert.ToString(user["Content"])
                    }).FirstOrDefault();

                }
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public void DeleteBlog(int blogId)
        {
            try
            {
                using (_sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "delete_blog";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = _sqlConnection;

                    SqlParameter titleParameter = new SqlParameter();
                    titleParameter.ParameterName = "@blogid";
                    titleParameter.SqlDbType = SqlDbType.Int;
                    titleParameter.Direction = ParameterDirection.Input;
                    titleParameter.Value = blogId;

                    sqlCommand.Parameters.Add(titleParameter);

                    _sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public List<Blog> GetBlogs()
        {
            try
            {
                using (_sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "get_allBlogs";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = _sqlConnection;

                    _sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dtBlogs = new DataTable();
                    dataAdapter.Fill(dtBlogs);


                    return dtBlogs.AsEnumerable().Select(user => new Blog()
                    {
                        BlogId = Convert.ToInt32(user["BlogId"]),
                        Title = Convert.ToString(user["Title"]),
                        Content = Convert.ToString(user["Content"])
                    }).ToList();

                }
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}


