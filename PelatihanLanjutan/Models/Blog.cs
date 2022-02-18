using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public User User { get; set; }
    }

    public class BlogDashBoard
    {
        public List<Blog> blog { get; set; }
        public List<User> user { get; set; }

        public BlogDashBoard()
        {
            blog = new List<Blog>();
            user = new List<User>();
        }
    }
}
