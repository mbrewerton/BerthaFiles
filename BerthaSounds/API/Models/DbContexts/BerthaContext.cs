using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Models.DbContexts
{
    public class BerthaContext : IdentityDbContext
    {
        public BerthaContext() : base("BerthaContext"){}

        public DbSet<Sound> Sound { get; set; }
        public DbSet<SoundPack> SoundPack { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Tag> Tag { get; set; }
    }
}
