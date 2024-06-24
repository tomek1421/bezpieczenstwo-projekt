using PersonApi.Entities;

namespace PersonApi.Repository.Contracts
{
	public interface IPeopleRepository
	{
		Task<IEnumerable<T>> GetAll<T>();
		Task<Person?> GetById(int id);
		Task<T?> GetById<T>(int id);
		void Add(Person person);
		void Update(Person person);
		void Delete(Person person);
		Task<bool> SafeChangesAsync(); 
	}
}
