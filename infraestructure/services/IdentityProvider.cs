using System;
using System.Security.Claims;
using Jose;
using Nancy;
using todoist.infraestructure.login;
using todoist.infraestructure.settings;

namespace todoist.infraestructure.services
{

    public interface IIdentityProvider
    {
        ClaimsPrincipal GetUserIdentity(NancyContext context);
    }

    internal sealed class IdentityProvider : IIdentityProvider
    {
        private readonly AuthSettings _authSettings;
        private const string _bearerDeclaration = "Bearer ";

        public IdentityProvider(AuthSettings authSettings)
        {
            _authSettings = authSettings;
        }

        public ClaimsPrincipal GetUserIdentity(NancyContext context)
        {
            try
            {
                var authorizationHeader = context.Request.Headers.Authorization;
                var jwt = authorizationHeader.Substring(_bearerDeclaration.Length);

                var authToken = Jose.JWT.Decode<AuthToken>(jwt, _authSettings.SecretKey, JwsAlgorithm.HS256);

                if (authToken.ExpirationDateTime < DateTime.UtcNow)
                    return null;

                var authUser = new AuthUser(authToken.UserName, authToken.UserLogin, authToken.UserId);
                return new ClaimsPrincipal(authUser);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}