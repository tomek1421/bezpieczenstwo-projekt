using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.DTOs;
using PersonApi.Entities;
using PersonApi.Repository.Contracts;

namespace PersonApi.Repository
{
	public class PeopleRepository(ApplicationDbContext context, IMapper mapper) : IPeopleRepository
	{
		public void Add(Person person)
		{
			context.People.Add(person);
		}

		public void Delete(Person person)
		{
			context.People.Remove(person);
		}

		public async Task<IEnumerable<T>> GetAll<T>()
		{
			return await context
				.People
				.ProjectTo<T>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<Person?> GetById(int id)
		{
			return await context.People.FindAsync(id);
		}

		public async Task<T?> GetById<T>(int id)
		{
			return await context
				.People
				.Where(p => p.Id == id)
				.ProjectTo<T>(mapper.ConfigurationProvider)
				.SingleOrDefaultAsync();
		}

		public async Task<bool> SafeChangesAsync()
		{
			return await context.SaveChangesAsync() > 0;
		}

		public void Update(Person person)
		{
			context.People.Update(person);
		}
	}
}
