using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClientSite.Models;
using System.Collections.Generic;
using System;

namespace ClientSite.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _http;

        public BlogService(HttpClient http)
        {
            _http = http;
        }

        // Use a relative path so the HttpClient BaseAddress from Program.cs is respected.
        private const string BaseUrl = "api/blogposts";

        public async Task<List<BlogPost>> GetAllBlogsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<BlogPost>>(BaseUrl)
                       ?? new List<BlogPost>();
            }
            catch
            {
                return new List<BlogPost>();
            }
        }

        public async Task<BlogPost?> GetBlogByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<BlogPost>($"{BaseUrl}/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<BlogPost?> GetBlogBySlugAsync(string slug)
        {
            try
            {
                return await _http.GetFromJsonAsync<BlogPost>($"{BaseUrl}/slug/{slug}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<BlogPost>> GetBlogsByCategoryAsync(string category)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<BlogPost>>($"{BaseUrl}/category/{category}")
                       ?? new List<BlogPost>();
            }
            catch
            {
                return new List<BlogPost>();
            }
        }

        public async Task<List<BlogPost>> GetFeaturedBlogsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<BlogPost>>($"{BaseUrl}/featured")
                       ?? new List<BlogPost>();
            }
            catch
            {
                return new List<BlogPost>();
            }
        }

        public async Task<List<BlogPost>> SearchBlogsAsync(string query)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<BlogPost>>($"{BaseUrl}/search?query={Uri.EscapeDataString(query)}")
                       ?? new List<BlogPost>();
            }
            catch
            {
                return new List<BlogPost>();
            }
        }

        public async Task<bool> CreateBlogAsync(BlogPost post)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(BaseUrl, post);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateBlogAsync(int id, BlogPost post)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", post);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}