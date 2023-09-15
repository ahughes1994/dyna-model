using DynaModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DynaModel.Api.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions b) : base(b)
        {            
        }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<IntProperty> IntProperty { get; set; }

        public DbSet<FloatProperty> FloatProperty { get; set; }

        public DbSet<StringProperty> StringProperty { get; set; }

        public DbSet<BoolProperty> BoolProperty { get; set; }
	}
}
