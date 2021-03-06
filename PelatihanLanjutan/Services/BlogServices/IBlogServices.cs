using PelatihanLanjutan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Services.BlogServices
{
    public interface IBlogServices
    {
        Task<List<Blog>> TampilSemuaBlogAsync();
        Task<Blog> TampilBlogIDAsync(int id);
        Task<bool> BuatBlog(Blog data, string username);
        Task<bool> HapusBlog(int id);
        Task<bool> UpdateBlog(int id);
    }
}
