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
	}
}
