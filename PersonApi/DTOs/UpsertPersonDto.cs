namespace PersonApi.DTOs
{
	public class UpsertPersonDto
	{
		public string Name { get; init; } = "";

		//public DateOnly DateOfBirth { get; init; }
		public int Age { get; init; }
	}
}
