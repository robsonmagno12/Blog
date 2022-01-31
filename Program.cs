using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
   class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            ReadWithRoles(connection);
           // CreateUser(connection);
           // ReadUser(connection);
            // ReadRoles(connection);
            // ReadTags(connection);

             connection.Close();
        }

        private static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
              var items = repository.Get();

             foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Email = "testando@hotmai.com",
                Bio = "bio",
                Image = "image",
                Name = "name",
                PasswordHash = "HASH",
                Slug = "slug"
            };
            var repository = new Repository<User>(connection);
          
        }

        private static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.ReadWithRole();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.roles) Console.WriteLine($" - {role.Slug}");
            }
        }

        private static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
              var items = repository.Get();

             foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
              var items = repository.Get();

             foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void ReadPosts(SqlConnection connection)
        {
            var repository = new Repository<Post>(connection);
              var items = repository.Get();

             foreach (var item in items)
                Console.WriteLine(item.Body);
        }

        private static void ReadCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
              var items = repository.Get();

             foreach (var item in items)
                Console.WriteLine(item.Name);
        }
   
    } 
  }

