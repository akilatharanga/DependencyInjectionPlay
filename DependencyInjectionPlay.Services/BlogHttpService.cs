using DependencyInjectionPlay.Models;
using DependencyInjectionPlay.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionPlay.Services
{
    public class BlogHttpService : IBlogService
    {
        private readonly HttpClient _httpClient;
        private List<Post> _posts;
        private Post _post;
        public BlogHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _posts = new List<Post>();
            _post = new Post();
        }
        public List<Post> GetAllPosts()
        {
            Task.Run(() => GetPostsAsync()).Wait();
            return _posts;
        }

        public Post GetPost(int id)
        {
            Task.Run(()=>GetPostAsync(id)).Wait();
            return _post;
        }

        private async Task GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("/posts");
            var content = await response.Content.ReadAsStringAsync();

            _posts = JsonConvert.DeserializeObject<List<Post>>(content);
        }

        private async Task GetPostAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/posts{id}");
            var content = await response.Content.ReadAsStringAsync();

            _post = JsonConvert.DeserializeObject<Post>(content);

        }
    }
}
