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

        public async Task<Blog> TampilBlogIDAsync(int id)
        {
            return await _blogRepo.TampilBlogIDAsync(id);
        }

        public Task<List<Blog>> TampilSemuaBlogAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Blog>> TampilSemuaData()
        {
            return await _blogRepo.TampilSemuaBlogAsync();
        }

    }
}
