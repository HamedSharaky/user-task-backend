using System.Collections.Generic;

namespace UserTask.Application.User.Queries.GetUserList
{
    public class UserListVm
    {
        public IList<UserLookupDto> User { get; set; }
    }
}
