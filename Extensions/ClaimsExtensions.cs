﻿using System.Security.Claims;
using WebGate.Shared;

namespace WebGate.Api.Extensions
{
    public static class ClaimsExtensions
    {
        public static long GetUserId(this ClaimsPrincipal user)
        {
            var id = user.FindFirstValue(Constants.UserIdClaimType);
            if (long.TryParse(id, out var userId))
            {
                return userId;
            }

            throw new InvalidOperationException($"Could not find a correct claim with type '{Constants.UserIdClaimType}'");
        }

        public static bool TryGetUserId(this ClaimsPrincipal user, out long userId)
        {
            var id = user.FindFirstValue(Constants.UserIdClaimType);
            return long.TryParse(id, out userId);
        }
    }
}