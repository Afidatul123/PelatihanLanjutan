using Microsoft.EntityFrameworkCore;
using PelatihanLanjutan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Repository.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _blogDB;

        public async Task<Blog> TampilBlogIDAsync(int id)
        {
            return await _blogDB.Tb_Blog.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<List<Blog>> TampilSemuaBlogAsync()
        {
            var data = await _blogDB.Tb_Blog.ToListAsync();
            return data;
        }
    }
}
