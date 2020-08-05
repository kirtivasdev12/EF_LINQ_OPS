// DB Context creation.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_LINQ_OPS.Models;

namespace EF_LINQ_OPS.DataAccess
{
     public class AppDBContext : DbContext
{
   public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

     public DbSet<Reviewer> Reviewers { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public DbSet<Items_reviewed> IRev { get; set; }

        public DbSet<ref_item_type> IType { get; set; }
    }
}
