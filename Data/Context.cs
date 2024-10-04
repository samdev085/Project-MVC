using Microsoft.EntityFrameworkCore;
using ProjectMVCv._2.Models;
using System.Collections.Generic;

namespace ProjectMVCv._2.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<NoticeTag> NoticesTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
