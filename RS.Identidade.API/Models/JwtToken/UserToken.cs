using System.Collections;
using System.Collections.Generic;

namespace RS.Identidade.API.Models.JwtToken
{
    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }
}
