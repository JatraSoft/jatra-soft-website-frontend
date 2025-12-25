using ClientSite.Models;

namespace ClientSite.Services
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetAllBlogsAsync();
        Task<BlogPost?> GetBlogByIdAsync(int id);
        Task<BlogPost?> GetBlogBySlugAsync(string slug);
        Task<List<BlogPost>> GetBlogsByCategoryAsync(string category);
        Task<List<BlogPost>> SearchBlogsAsync(string query);
        Task<List<BlogPost>> GetFeaturedBlogsAsync();

        Task<bool> CreateBlogAsync(BlogPost post);
        Task<bool> UpdateBlogAsync(int id, BlogPost post);
        Task<bool> DeleteBlogAsync(int id);
    }
}
