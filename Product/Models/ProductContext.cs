using Microsoft.EntityFrameworkCore;
using Product.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{
    public class ProductContext: DbContext
    {
        public DbSet<Producto> Products { get; set; }
        public IEnumerable<object> Category { get; internal set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
