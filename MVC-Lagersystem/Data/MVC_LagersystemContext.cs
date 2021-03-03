using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Lagersystem.Models;

namespace MVC_Lagersystem.Data
{
    public class MVC_LagersystemContext : DbContext
    {
        public MVC_LagersystemContext (DbContextOptions<MVC_LagersystemContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductViewModel> ProductViewModels { get; set; }
    }
}
