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

        public BlogRepository(AppDbContext x)
        {
            _blogDB = x;
        }
        public async Task<bool> BuatBlogAsync(Blog datanya)
        {
            _blogDB.Tb_Blog.Add(datanya); //  insert into tb_blog...
            await _blogDB.SaveChangesAsync(); // eksekusi
            return true;
        }

        public Task cariBlogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> cariUserByUsernameAsync(string username)
        {
            return await _blogDB.Tb_User.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task<bool> HapusBlogAsync(Blog datanya)
        {
            _blogDB.Tb_Blog.Remove(datanya); // delete from tb_blog
            await _blogDB.SaveChangesAsync(); // eksekusi
            return true;
        }

        public async Task<Blog> TampilBlogIDAsync(int id)
        {
            return await _blogDB.Tb_Blog.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<List<Blog>> TampilSemuaBlogAsync()
        {
            var data = await _blogDB.Tb_Blog.ToListAsync(); // select *
            return data;
        }

        public async Task<bool> UpdateBlogAsync(Blog datanya)
        {
            _blogDB.Tb_Blog.Update(datanya);
            await _blogDB.SaveChangesAsync();
            return true;
        }
    }
}
