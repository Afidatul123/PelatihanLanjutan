using PelatihanLanjutan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Repository.BlogRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> TampilSemuaBlogAsync();
        Task<Blog> TampilBlogIDAsync(int id);
    }
}
