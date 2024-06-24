using System.Net.Cache;

namespace PersonApi.DTOs
{
	public class PersonDto
	{
        public int Id { get; init; }
		public string Name { get; init; } = "";
		public int Age { get; init; }
    }
}
