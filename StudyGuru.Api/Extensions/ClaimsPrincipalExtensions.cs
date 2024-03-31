using System.Security.Claims;

namespace StudyGuru.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        if (user.FindFirst("sub") is { } claim && Guid.TryParse(claim.Value, out var userId))
        {
            return userId;
        }

        return null;
    }
}