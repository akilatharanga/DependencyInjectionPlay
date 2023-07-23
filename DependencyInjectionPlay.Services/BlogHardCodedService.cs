using DependencyInjectionPlay.Data;
using DependencyInjectionPlay.Models;
using DependencyInjectionPlay.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionPlay.Services
{
    public class BlogHardCodedService : IBlogService
    {
        public List<Post> GetAllPosts()
        {
            var blogData = new HardCodedData();

            return blogData.Posts();
        }

        public Post GetPost(int id)
        {
            var blogData = new HardCodedData();
            return blogData.Posts().SingleOrDefault(p => p.Id == id);
        }
    }
}
