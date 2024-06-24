using PersonApi.Objects;
using System.Security.Claims;
using System.Text.Json;


namespace PersonApi.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static List<string>? GetApiClientRoles(this ClaimsPrincipal claimsPrincipal)
		{
			var resourseAccessClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "resource_access")?.Value;
			if (resourseAccessClaim is null) return null;
			var deserializedJson = JsonSerializer.Deserialize<ResourceAccessClaimValue>(resourseAccessClaim);
			return deserializedJson?.ApiClient?.Roles;
		}
	}
}
