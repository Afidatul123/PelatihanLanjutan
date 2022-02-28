using PelatihanLanjutan.Helper;
using PelatihanLanjutan.Models;
using PelatihanLanjutan.Repository.BlogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Services.BlogServices
{
    public class BlogServices : IBlogServices
    {
        private readonly IBlogRepository _blogRepo;
        public BlogServices(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public async Task<bool> BuatBlog(Blog data, string username)
        {
            //data.Id = BuatPrimary.buatPrimary();
            var cariUser = await _blogRepo.cariUserByUsernameAsync(username);
            data.User = cariUser;

            return await _blogRepo.BuatBlogAsync(data);
        }

        public async Task<bool> HapusBlog(int id)
        {
            var cari = await _blogRepo.TampilBlogIDAsync(id);
            await _blogRepo.HapusBlogAsync(cari);
            return true;
        }

        public async Task<Blog> TampilBlogIDAsync(int id)
        {
            return await _blogRepo.TampilBlogIDAsync(id);
        }

        public async Task<List<Blog>> TampilSemuaBlogAsync()
        {
            return await _blogRepo.TampilSemuaBlogAsync();
        }

        public async Task<List<Blog>> TampilSemuaData()
        {
            return await _blogRepo.TampilSemuaBlogAsync();
        }


        public async Task<bool> UpdateBlog(Blog data)
        {
            var cari = await _blogRepo.TampilBlogIDAsync(data.Id);
            cari.Title = data.Title;
            cari.Content = data.Content;
            cari.Status = data.Status;

            return await _blogRepo.UpdateBlogAsync(cari);
        }

        public Task<bool> UpdateBlog(int id)
        {
            throw new NotImplementedException();
        }
    }
}
