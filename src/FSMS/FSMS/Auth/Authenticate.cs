using Newtonsoft.Json;

namespace FSMS.Auth
{
    public class Authenticate(IHttpContextAccessor httpContextAccessor)
    {
        public UserSession? GetAuthenticationState()
        {
            var userSession = httpContextAccessor!.HttpContext!.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userSession))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserSession>(userSession);
        }

        public void UpdateAuthenticationState(UserSession user)
        {
            httpContextAccessor!.HttpContext!.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
        }

        public void ClearAuthenticationState()
        {
            httpContextAccessor!.HttpContext!.Session.Remove("UserSession");
        }

        public bool HasRole(string role)
        {
            var user = GetAuthenticationState();
            return user != null && user.Roles!.Contains(role);
        }
    }
}
