using PelatihanLanjutan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Repository.BlogRepository
{
    public interface IBlogRepository
    {
        Task<bool> BuatBlogAsync(Blog datanya);
        Task<List<Blog>> TampilSemuaBlogAsync();
        Task<Blog> TampilBlogIDAsync(int id);
        Task<bool> UpdateBlogAsync(Blog datanya);
        Task<bool> HapusBlogAsync(Blog datanya);
        Task<User> cariUserByUsernameAsync(string username);
        Task cariBlogAsync(int id);
    }
}
