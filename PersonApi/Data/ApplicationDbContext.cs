using Microsoft.EntityFrameworkCore;
using PersonApi.Entities;

namespace PersonApi.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<Person> People { get; init; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasData(new List<Person>
			{
				/*new Person { Id = 1, Name = "Foo", DateOfBirth = new DateOnly(2022, 12, 12)},
				new Person { Id = 2, Name = "Doe", DateOfBirth = new DateOnly(2022, 12, 12)}*/
				new Person { Id = 1, Name = "Doe", Age = 23},
				new Person { Id = 2, Name = "Foo", Age = 18}
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
