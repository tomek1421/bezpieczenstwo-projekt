

using System.Text.Json.Serialization;

namespace PersonApi.Objects
{
	public class ResourceAccessClaimValue
	{
		[JsonPropertyName("api-client")]
		public ApiClient? ApiClient { get; set; }

		[JsonPropertyName("account")]
		public Account? Account { get; set; }
	}

	public class ApiClient
	{
		[JsonPropertyName("roles")]
		public List<string>? Roles { get; set; }
	}

	public class Account
	{
		[JsonPropertyName("roles")]
		public List<string>? Roles { get; set; }
	}
}
