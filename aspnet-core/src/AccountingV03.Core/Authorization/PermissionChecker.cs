using Abp.Authorization;
using AccountingV03.Authorization.Roles;
using AccountingV03.Authorization.Users;

namespace AccountingV03.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
