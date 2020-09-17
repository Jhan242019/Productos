using Microsoft.EntityFrameworkCore;
using Product.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{
    public class CategoryContext: DbContext
    {
        public DbSet<Categoria> Categorys { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
