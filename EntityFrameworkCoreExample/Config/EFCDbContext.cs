using System;
using EntityFrameworkCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Config
{
    public class EFCDbContext : DbContext
    {
	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    base.OnConfiguring(optionsBuilder);

		    var connectionString = "Data Source=.;Initial Catalog=AppDb;Integrated Security=True";
		    optionsBuilder.UseSqlServer(connectionString);
	    }

	    public DbSet<PostModel> Posts { get; set; }
    }
}
